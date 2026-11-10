using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mizon.Database;

internal static class DatabaseBenchmarks
{
    // No connection is opened: these cases isolate EF model/context overhead.
    private const string Connection = "Server=localhost;Database=MizonBenchmarkNoConnection;Integrated Security=True;TrustServerCertificate=True";
    private static int _observed;

    public static void Run(string outputPath)
    {
        const int batches = 15;
        const int operationsPerBatch = 2_000;
        var allocated = GC.GetAllocatedBytesForCurrentThread();
        var started = Stopwatch.GetTimestamp();
        var options = new DbContextOptionsBuilder<MizonDatabaseContext>().UseSqlServer(Connection).Options;
        using (var context = new MizonDatabaseContext(options))
            _observed = context.Model.GetEntityTypes().Count();
        var coldMs = Stopwatch.GetElapsedTime(started).TotalMilliseconds;
        var coldBytes = GC.GetAllocatedBytesForCurrentThread() - allocated;
        var entityCount = _observed;

        var factory = new PooledDbContextFactory<MizonDatabaseContext>(options, poolSize: 1);
        var results = new List<DatabaseBenchmarkMeasurement>
        {
            new("ColdModelAndProvider", 1, 1, coldMs, coldMs, coldBytes),
            Measure("NewContextAndSet", () =>
            {
                using var context = new MizonDatabaseContext(options);
                _observed = context.Musics.EntityType.GetProperties().Count();
            }, batches, operationsPerBatch),
            Measure("PooledContextAndSet", () =>
            {
                using var context = factory.CreateDbContext();
                _observed = context.Musics.EntityType.GetProperties().Count();
            }, batches, operationsPerBatch)
        };

        var report = new DatabaseBenchmarkReport(RuntimeInformation.FrameworkDescription,
            typeof(DbContext).Assembly.GetName().Version!.ToString(), entityCount,
            batches, operationsPerBatch, results);
        var fullPath = Path.GetFullPath(outputPath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, JsonSerializer.Serialize(report, DatabaseBenchmarkJson.Default.DatabaseBenchmarkReport));
        foreach (var item in results)
            Console.WriteLine($"{item.Name}: median={item.MedianMilliseconds:F6}ms p95={item.P95Milliseconds:F6}ms allocated={item.AllocatedBytesPerOperation:F1}B/op");
        Console.WriteLine($"Runtime={report.Runtime}; EF={report.EntityFramework}; entities={entityCount}; no SQL connections.");
        GC.KeepAlive(_observed);
    }

    private static DatabaseBenchmarkMeasurement Measure(string name, Action operation, int batches, int count)
    {
        // Warm code and model caches before recording; process repetitions are still
        // required to distinguish a runtime change from background machine noise.
        for (var i = 0; i < 2_000; i++) operation();
        var milliseconds = new double[batches];
        var allocations = new double[batches];
        for (var batch = 0; batch < batches; batch++)
        {
            var allocated = GC.GetAllocatedBytesForCurrentThread();
            var started = Stopwatch.GetTimestamp();
            for (var i = 0; i < count; i++) operation();
            milliseconds[batch] = Stopwatch.GetElapsedTime(started).TotalMilliseconds / count;
            allocations[batch] = (GC.GetAllocatedBytesForCurrentThread() - allocated) / (double)count;
        }
        Array.Sort(milliseconds);
        Array.Sort(allocations);
        return new(name, batches, count, milliseconds[batches / 2],
            milliseconds[(int)Math.Ceiling(batches * .95) - 1], allocations[batches / 2]);
    }
}

internal sealed record DatabaseBenchmarkReport(string Runtime, string EntityFramework,
    int EntityCount, int Batches, int OperationsPerBatch, List<DatabaseBenchmarkMeasurement> Measurements);

internal sealed record DatabaseBenchmarkMeasurement(string Name, int Batches, int OperationsPerBatch,
    double MedianMilliseconds, double P95Milliseconds, double AllocatedBytesPerOperation);

[JsonSerializable(typeof(DatabaseBenchmarkReport))]
[JsonSourceGenerationOptions(WriteIndented = true)]
internal partial class DatabaseBenchmarkJson : JsonSerializerContext;
