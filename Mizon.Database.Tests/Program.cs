using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mizon.Database;
using Mizon.Database.CompiledModels;
using Mizon.Database.Entities;

if (args is ["--benchmark", var outputPath])
{
    DatabaseBenchmarks.Run(outputPath);
    return;
}

// Saves are intercepted before SQL is sent. These checks cover tracking and dispatch;
// they do not simulate a database write or AcceptAllChanges after a successful write.
var modes = new SaveMode[]
{
    new("SaveChanges()", true, false, (context, _) => Task.FromResult(context.SaveChanges())),
    new("SaveChanges(true)", true, false, (context, _) => Task.FromResult(context.SaveChanges(true))),
    new("SaveChanges(false)", false, false, (context, _) => Task.FromResult(context.SaveChanges(false))),
    new("SaveChangesAsync(token)", true, true, (context, token) => context.SaveChangesAsync(token)),
    new("SaveChangesAsync(true, token)", true, true, (context, token) => context.SaveChangesAsync(true, token)),
    new("SaveChangesAsync(false, token)", false, true, (context, token) => context.SaveChangesAsync(false, token))
};

var passed = 0;
await Run("Default context resolves the generated compiled model", VerifyCompiledModel);
await Run("Convention-only entities retain table names and cached sets", VerifyConventionEntities);
await Run("Pooled context resets after Dispose", () => VerifyPooledContext(false));
await Run("Pooled context resets after DisposeAsync", () => VerifyPooledContext(true));

foreach (var mode in modes)
{
    await Run($"{mode.Name}: metadata and overload dispatch", () => VerifyMetadata(mode));
    await Run($"{mode.Name}: automatic change detection disabled", () => VerifyDisabledDetection(mode));
    await Run($"{mode.Name}: SavingChanges event mutation", () => VerifyEventMutation(mode));
    await Run($"{mode.Name}: interceptor mutation", () => VerifyInterceptorMutation(mode));
    await Run($"{mode.Name}: exception propagation", () => VerifyException(mode));

    if (mode.IsAsync)
    {
        await Run($"{mode.Name}: pre-cancelled token", () => VerifyPreCancelled(mode));
        await Run($"{mode.Name}: cancellation during saving", () => VerifyCancellationDuringSaving(mode));
    }
}

Console.WriteLine($"Passed {passed} database regression checks. No SQL connections were opened.");

async Task Run(string name, Func<Task> test)
{
    await test();
    passed++;
    Console.WriteLine($"PASS {name}");
}

static MizonDatabaseContext CreateContext(SuppressSaveChangesInterceptor interceptor)
{
    var options = new DbContextOptionsBuilder<MizonDatabaseContext>()
        .UseSqlServer("Server=localhost;Database=MizonRegressionChecks;Integrated Security=True;TrustServerCertificate=True")
        .AddInterceptors(interceptor)
        .Options;
    return new MizonDatabaseContext(options);
}

static ClientEmail CreateEmail(int id) => new()
{
    Id = id,
    ClientId = 1,
    Email = $"client{id}@example.test",
    CreateDateTime = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero),
    UpdateDateTime = new DateTimeOffset(2001, 1, 1, 0, 0, 0, TimeSpan.Zero)
};

static async Task VerifyCompiledModel()
{
    // CreateContext deliberately does not call UseModel: the generated registration
    // must select the compiled model for an ordinary consuming application.
    await using var context = CreateContext(new SuppressSaveChangesInterceptor());
    await using var otherContext = CreateContext(new SuppressSaveChangesInterceptor());

    Assert(context.Model is MizonDatabaseContextModel, "The default context rebuilt its model instead of using the generated model.");
    Assert(ReferenceEquals(context.Model, MizonDatabaseContextModel.Instance), "The default context did not resolve the generated model instance.");
    Assert(ReferenceEquals(context.Model, otherContext.Model), "Contexts did not share their compiled model.");
}

static async Task VerifyConventionEntities()
{
    await using var context = CreateContext(new SuppressSaveChangesInterceptor());

    VerifySet(context, () => context.MusicComments, "MusicComments");
    VerifySet(context, () => context.MusicLyrics, "MusicLyrics");
    VerifySet(context, () => context.MusicLyricLines, "MusicLyricLines");
    VerifySet(context, () => context.MusicLyricLineWords, "MusicLyricLineWords");
}

static void VerifySet<TEntity>(MizonDatabaseContext context, Func<DbSet<TEntity>> getSet, string tableName)
    where TEntity : class
{
    var entityType = context.Model.FindEntityType(typeof(TEntity));
    Assert(entityType is not null, $"The model did not discover {typeof(TEntity).Name}.");
    Assert(entityType!.GetTableName() == tableName, $"The convention table name for {typeof(TEntity).Name} changed.");

    var set = getSet();
    Assert(ReferenceEquals(set, getSet()), $"Repeated {tableName} getter calls created different sets.");
    Assert(ReferenceEquals(set, context.Set<TEntity>()), $"The {tableName} getter did not use the context's cached set.");
}

static async Task VerifyPooledContext(bool disposeAsync)
{
    var options = new DbContextOptionsBuilder<MizonDatabaseContext>()
        .UseSqlServer("Server=localhost;Database=MizonRegressionChecks;Integrated Security=True;TrustServerCertificate=True")
        .AddInterceptors(new SuppressSaveChangesInterceptor())
        .Options;
    var factory = new PooledDbContextFactory<MizonDatabaseContext>(options, poolSize: 1);
    var context = factory.CreateDbContext();
    DbSet<ClientEmail>? originalSet = null;
    try
    {
        Assert(context.ChangeTracker.AutoDetectChangesEnabled, "A new pooled context did not enable change detection.");
        Assert(context.ChangeTracker.QueryTrackingBehavior == QueryTrackingBehavior.TrackAll, "A new pooled context did not use default query tracking.");
        originalSet = context.ClientEmails;
        originalSet.Add(CreateEmail(1));
        Assert(context.ChangeTracker.Entries().Count() == 1, "The first pooled lease did not track its entity.");
        context.ChangeTracker.AutoDetectChangesEnabled = false;
        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    finally
    {
        if (disposeAsync)
            await context.DisposeAsync();
        else
            context.Dispose();
    }

    await using var reusedContext = await factory.CreateDbContextAsync();
    Assert(ReferenceEquals(context, reusedContext), "The disposed context was not returned to the pool.");
    Assert(reusedContext.ChangeTracker.AutoDetectChangesEnabled, "A pooled lease retained disabled change detection.");
    Assert(reusedContext.ChangeTracker.QueryTrackingBehavior == QueryTrackingBehavior.TrackAll, "A pooled lease retained its previous query tracking mode.");
    Assert(!reusedContext.ChangeTracker.Entries().Any(), "A pooled lease retained entities from its previous lease.");
    Assert(ReferenceEquals(originalSet, reusedContext.ClientEmails), "The pooled context did not reuse its cached DbSet.");
    Assert(reusedContext.ClientEmails.Local.Count == 0, "The cached DbSet retained entities from its previous lease.");
    Assert(ReferenceEquals(reusedContext.Model, MizonDatabaseContextModel.Instance), "The pooled context did not retain the generated model.");

    reusedContext.ClientEmails.Add(CreateEmail(2));
    Assert(reusedContext.ChangeTracker.Entries().Count() == 1, "A reused pooled context did not track a new entity.");
}

static async Task VerifyMetadata(SaveMode mode)
{
    var interceptor = new SuppressSaveChangesInterceptor();
    await using var context = CreateContext(interceptor);
    var added = CreateEmail(1);
    var supplied = CreateEmail(2);
    var suppliedId = Guid.NewGuid();
    supplied.PublicId = suppliedId;
    var modified = CreateEmail(3);
    var unchanged = CreateEmail(4);
    var deleted = CreateEmail(5);
    var originalCreateDateTime = modified.CreateDateTime;
    var originalUpdateDateTime = modified.UpdateDateTime;
    var addedEntry = context.Add(added);
    context.Add(supplied);
    var modifiedEntry = context.Attach(modified);
    modifiedEntry.Property(item => item.Email).IsModified = true;
    var unchangedEntry = context.Attach(unchanged);
    var deletedEntry = context.Remove(deleted);
    var createdOnly = new ClientSessionIp { Id = 1, ClientSessionId = 1, IpAddress = "127.0.0.1" };
    context.Add(createdOnly);

    var savingCalls = 0;
    var detectionCalls = 0;
    context.SavingChanges += (_, args) =>
    {
        savingCalls++;
        Assert(args.AcceptAllChangesOnSuccess == mode.AcceptAllChanges, "The accept-all-changes flag was not forwarded.");
    };
    context.ChangeTracker.DetectedAllChanges += (_, _) => detectionCalls++;
    using var cancellation = new CancellationTokenSource();
    var before = DateTimeOffset.UtcNow;
    var result = await mode.Save(context, cancellation.Token);
    var after = DateTimeOffset.UtcNow;

    Assert(result == SuppressSaveChangesInterceptor.Result, "The base save result was not returned.");
    Assert(savingCalls == 1, "The save pipeline was entered more than once.");
    Assert(interceptor.SavingCalls == 1, "The interceptor was entered more than once.");
    Assert(interceptor.SavedCalls == 1, "The save did not complete exactly once.");
    Assert(detectionCalls == 2, "Metadata and base save must each keep their detection pass.");
    Assert(added.CreateDateTime >= before && added.CreateDateTime <= after, "Added entity creation time was not stamped.");
    Assert(added.PublicId != Guid.Empty && added.PublicId.ToString("D")[14] == '7', "Added entity did not receive a version 7 GUID.");
    Assert(supplied.PublicId == suppliedId, "An explicitly supplied public ID was replaced.");
    Assert(supplied.CreateDateTime == added.CreateDateTime, "Added entities must share one save timestamp.");
    Assert(createdOnly.CreateDateTime == added.CreateDateTime, "ICreate-only entities must be stamped.");
    Assert(added.UpdateDateTime == originalUpdateDateTime, "Added entity update time changed.");
    Assert(modified.UpdateDateTime == added.CreateDateTime, "Modified entity update time was not stamped.");
    Assert(modified.CreateDateTime == originalCreateDateTime, "Modified entity creation time changed.");
    Assert(modified.PublicId == Guid.Empty, "Modified entity public ID changed.");
    Assert(modifiedEntry.Property(item => item.UpdateDateTime).IsModified, "The stamped update time was not detected.");
    Assert(unchanged.CreateDateTime == originalCreateDateTime && unchanged.UpdateDateTime == originalUpdateDateTime, "Unchanged entity metadata changed.");
    Assert(unchanged.PublicId == Guid.Empty && unchangedEntry.State == EntityState.Unchanged, "An unchanged entity was modified.");
    Assert(deleted.CreateDateTime == originalCreateDateTime && deleted.UpdateDateTime == originalUpdateDateTime, "Deleted entity metadata changed.");
    Assert(deleted.PublicId == Guid.Empty && deletedEntry.State == EntityState.Deleted, "Deleted entity state or ID changed.");
    Assert(context.ChangeTracker.AutoDetectChangesEnabled, "Automatic detection was not preserved.");
    if (!mode.AcceptAllChanges)
    {
        Assert(addedEntry.State == EntityState.Added, "SaveChanges(false) accepted the added entity.");
        Assert(modifiedEntry.State == EntityState.Modified, "SaveChanges(false) accepted the modified entity.");
    }
    if (mode.IsAsync)
        Assert(interceptor.CancellationToken == cancellation.Token, "The cancellation token was not forwarded.");
}

static async Task VerifyDisabledDetection(SaveMode mode)
{
    var interceptor = new SuppressSaveChangesInterceptor();
    await using var context = CreateContext(interceptor);
    var unchanged = CreateEmail(1);
    var unchangedEntry = context.Attach(unchanged);
    var modified = CreateEmail(2);
    var modifiedEntry = context.Attach(modified);
    modifiedEntry.Property(item => item.Email).IsModified = true;
    var added = CreateEmail(3);
    context.Add(added);
    context.ChangeTracker.AutoDetectChangesEnabled = false;
    var originalUpdateDateTime = unchanged.UpdateDateTime;
    unchanged.Email = "changed-without-detection@example.test";
    var detectionCalls = 0;
    context.ChangeTracker.DetectedAllChanges += (_, _) => detectionCalls++;

    await mode.Save(context, default);

    Assert(detectionCalls == 0, "SaveChanges enabled automatic detection against the caller's setting.");
    Assert(!context.ChangeTracker.AutoDetectChangesEnabled, "The caller's automatic detection setting changed.");
    Assert(unchangedEntry.State == EntityState.Unchanged, "An undetected entity change was detected.");
    Assert(unchanged.UpdateDateTime == originalUpdateDateTime, "An unchanged entry received an update timestamp.");
    Assert(modified.UpdateDateTime == added.CreateDateTime, "An explicitly modified entry was not stamped.");
    Assert(modifiedEntry.Property(item => item.UpdateDateTime).IsModified, "The timestamp must be persisted even when automatic detection is disabled.");
    Assert(added.PublicId != Guid.Empty, "An added entry was not stamped with detection disabled.");
}

static async Task VerifyEventMutation(SaveMode mode)
{
    var interceptor = new SuppressSaveChangesInterceptor();
    await using var context = CreateContext(interceptor);
    var entity = CreateEmail(1);
    var entry = context.Attach(entity);
    var detectedAfterEvent = false;
    var eventRaised = false;
    context.SavingChanges += (_, _) =>
    {
        entity.Email = "changed-in-event@example.test";
        eventRaised = true;
    };
    context.ChangeTracker.DetectedAllChanges += (_, _) =>
    {
        if (eventRaised)
            detectedAfterEvent = true;
    };

    await mode.Save(context, default);

    Assert(detectedAfterEvent, "Base save skipped detection after SavingChanges.");
    Assert(entry.State == EntityState.Modified, "A SavingChanges handler mutation was not detected.");
    Assert(entry.Property(item => item.Email).IsModified, "The handler's scalar change was not marked for persistence.");
}

static async Task VerifyInterceptorMutation(SaveMode mode)
{
    var interceptor = new SuppressSaveChangesInterceptor();
    await using var context = CreateContext(interceptor);
    var entity = CreateEmail(1);
    var entry = context.Attach(entity);
    interceptor.OnSaving = () => entity.Email = "changed-in-interceptor@example.test";

    await mode.Save(context, default);

    Assert(entry.State == EntityState.Modified, "A save interceptor mutation was not detected.");
    Assert(entry.Property(item => item.Email).IsModified, "The interceptor's scalar change was not marked for persistence.");
}

static async Task VerifyException(SaveMode mode)
{
    var expected = new InvalidOperationException("Expected regression-test failure.");
    var interceptor = new SuppressSaveChangesInterceptor { OnSaving = () => throw expected };
    await using var context = CreateContext(interceptor);
    var entity = CreateEmail(1);
    var entry = context.Add(entity);
    var originalCreateDateTime = entity.CreateDateTime;

    var actual = await Throws<InvalidOperationException>(() => mode.Save(context, default));

    Assert(ReferenceEquals(actual, expected), "The original save exception was replaced.");
    Assert(entity.CreateDateTime != originalCreateDateTime && entity.PublicId != Guid.Empty, "Metadata behavior before a failed save changed.");
    Assert(entry.State == EntityState.Added, "A failed save accepted entity changes.");
    Assert(context.ChangeTracker.AutoDetectChangesEnabled, "A failed save changed automatic detection.");
    Assert(interceptor.SavingCalls == 1 && interceptor.SavedCalls == 0, "A failed save was retried or reported as successful.");
}

static async Task VerifyPreCancelled(SaveMode mode)
{
    var interceptor = new SuppressSaveChangesInterceptor();
    await using var context = CreateContext(interceptor);
    var entity = CreateEmail(1);
    context.Add(entity);
    var originalCreateDateTime = entity.CreateDateTime;
    var originalUpdateDateTime = entity.UpdateDateTime;
    var detectionCalls = 0;
    context.ChangeTracker.DetectedAllChanges += (_, _) => detectionCalls++;
    using var cancellation = new CancellationTokenSource();
    cancellation.Cancel();

    var task = mode.Save(context, cancellation.Token);
    var exception = await Throws<OperationCanceledException>(() => task);

    Assert(task.IsCanceled, "A pre-cancelled save did not return a cancelled task.");
    Assert(exception.CancellationToken == cancellation.Token, "The cancellation token was lost.");
    Assert(entity.PublicId == Guid.Empty, "A pre-cancelled save generated an ID.");
    Assert(entity.CreateDateTime == originalCreateDateTime && entity.UpdateDateTime == originalUpdateDateTime, "A pre-cancelled save changed metadata.");
    Assert(detectionCalls == 0 && interceptor.SavingCalls == 0, "A pre-cancelled save entered the EF save pipeline.");
    Assert(context.ChangeTracker.AutoDetectChangesEnabled, "A pre-cancelled save changed automatic detection.");
}

static async Task VerifyCancellationDuringSaving(SaveMode mode)
{
    using var cancellation = new CancellationTokenSource();
    var interceptor = new SuppressSaveChangesInterceptor();
    await using var context = CreateContext(interceptor);
    var entity = CreateEmail(1);
    var entry = context.Add(entity);
    context.SavingChanges += (_, _) => cancellation.Cancel();

    var exception = await Throws<OperationCanceledException>(() => mode.Save(context, cancellation.Token));

    Assert(exception.CancellationToken == cancellation.Token, "Cancellation during saving lost the original token.");
    Assert(entity.PublicId != Guid.Empty, "Metadata was unexpectedly rolled back after cancellation during saving.");
    Assert(entry.State == EntityState.Added, "A cancelled save accepted entity changes.");
    Assert(context.ChangeTracker.AutoDetectChangesEnabled, "A cancelled save changed automatic detection.");
    Assert(interceptor.SavingCalls == 1 && interceptor.SavedCalls == 0, "A cancelled save was reported as successful.");
}

static void Assert(bool condition, string message)
{
    if (!condition)
        throw new InvalidOperationException(message);
}

static async Task<TException> Throws<TException>(Func<Task<int>> action) where TException : Exception
{
    try
    {
        await action();
    }
    catch (TException exception)
    {
        return exception;
    }

    throw new InvalidOperationException($"Expected {typeof(TException).Name}.");
}

internal sealed record SaveMode(
    string Name,
    bool AcceptAllChanges,
    bool IsAsync,
    Func<MizonDatabaseContext, CancellationToken, Task<int>> Save);

internal sealed class SuppressSaveChangesInterceptor : SaveChangesInterceptor
{
    public const int Result = 17;
    public int SavingCalls { get; private set; }
    public int SavedCalls { get; private set; }
    public CancellationToken CancellationToken { get; private set; }
    public Action? OnSaving { get; set; }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SavingCalls++;
        OnSaving?.Invoke();
        return InterceptionResult<int>.SuppressWithResult(Result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        SavingCalls++;
        CancellationToken = cancellationToken;
        cancellationToken.ThrowIfCancellationRequested();
        OnSaving?.Invoke();
        return ValueTask.FromResult(InterceptionResult<int>.SuppressWithResult(Result));
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        SavedCalls++;
        return result;
    }

    public override ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        SavedCalls++;
        return ValueTask.FromResult(result);
    }
}
