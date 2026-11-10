# Mizon.Database

Targets .NET 11 and uses the same EF Core 11.0.0 package family as the API.
The repository pins SDK 11.0.100 with patch roll-forward in `global.json`.

## Build and runtime model

`Microsoft.EntityFrameworkCore.Tasks` generates the compiled model as part of a
normal build. The generated sources stay under the configuration/platform-specific
`obj` directory; do not edit or check them in. EF discovers the generated model
automatically, including when a consumer constructs the context directly.

EF invokes generation before the normal output copy. The project's
`PrepareCurrentAssemblyForEfModelGeneration` target supplies the current assembly
and runtime/dependency files first, so a fresh build works and an existing build
cannot generate a model from the previous assembly. Fresh x64, first model-change
and artifacts-path builds were verified in an isolated copy.

Model generation is disabled for Visual Studio design-time builds. A real build
regenerates the model after source changes, so entity/configuration changes do not
require a separate manual generation command. Migration tooling continues to use
`MizonDatabaseContextFactory` and the design-time model.

The library enables trimming/AOT analysis through `IsAotCompatible`. Executable
publishing settings belong to the consuming application, not this class library.

## Context behavior

- DbSets use cached `Set<TEntity>()` getters. A fresh context does not eagerly
  create all 68 sets when it only needs one or two.
- All synchronous/asynchronous save overloads run metadata stamping exactly once.
  The accept-changes flag and cancellation token are forwarded to EF.
- A pre-cancelled async save does not stamp entities.
- Update timestamps are marked through the tracked property, including when a
  caller has disabled automatic change detection.
- EF's normal detection pass after save events/interceptors is preserved.
- Default tracking is unchanged. Existing operations that mutate loaded entities
  continue to save those changes. The API's existing context pooling is preserved.

`GlobalUsings.cs` intentionally contains only the four shared EF/entity namespaces.
`Configurations` and `Microsoft.EntityFrameworkCore.Design` remain local to the
two files that need them. Standard framework namespaces come from ImplicitUsings.

## Regression checks

From the parent directory:

```powershell
dotnet run --project Mizon.Database.Tests -c Release
```

The console runner performs 40 checks without opening a SQL connection. It covers
compiled-model selection, convention table names, cached DbSets, pool reset after
Dispose/DisposeAsync, save overloads, metadata, manual tracking, events,
interceptors, cancellation and exception propagation.

Native publishing can be checked separately:

The historical .NET 10 native run passed all 40 checks. Current migration validation
is recorded in [the handoff](../docs/ai/HANDOFF.md); a model-only native run does not
certify the complete API query pipeline.

```powershell
dotnet publish Mizon.Database.Tests -c Release -r win-x64 -p:PublishAot=true -p:DebugType=None -p:DebugSymbols=false
.\Mizon.Database.Tests\bin\Release\net11.0\win-x64\publish\Mizon.Database.Tests.exe
```

## .NET 11 upgrade

EF 11 removes `EFOptimizeContext`. Model generation now uses
`EFScaffoldModelStage=build` directly, with `none` for design-time builds;
consumer query precompilation remains separate. The explicit Design package
reference is retained because Tools/Tasks 11 no longer bring it transitively.

SQL Server defaults to compatibility 160 in EF 11. The development database was
verified read-only as SQL Server 17.0.1145.4 / compatibility 170, so it supports
that default. No database compatibility level or schema was changed. Deployments
on older databases must set a supported `UseCompatibilityLevel` in their host.
SqlClient 7 separates Azure authentication dependencies; the current integrated
Windows authentication needs no Azure extension package.

The opt-in benchmark performs no SQL connections or writes:

```powershell
dotnet build Mizon.Database.Tests -c Release -p:Platform=x64
dotnet Mizon.Database.Tests/bin/x64/Release/net11.0/Mizon.Database.Tests.dll --benchmark D:/MizonTaskDiagnostics/database.json
```

It records cold compiled-model/provider initialization and warmed fresh/pooled
context access. Each warm case runs 2,000 warm-up operations followed by 15
batches of 2,000; timings and current-thread allocated bytes are per operation.
Repeat in separate processes and compare identical source/configuration on both
runtimes. The cold observation is one sample per process, not a statistically
meaningful p95 by itself. These results do not measure SQL/server/network/UI memory.

## Measurements on the development machine

2026-11-08, Release, 64-bit .NET 10. These are small local measurements, not a
prediction of server throughput or the Windows app's working set.

| Measurement | Before | After |
| --- | ---: | ---: |
| Managed allocations while creating/accessing the cold model | about 51.2 MB | about 6.9 MB |
| Allocations for 10,000 fresh contexts, accessing one set and initializing context services | about 755.8 MB | about 651.3 MB |

The second comparison isolates eager versus deferred DbSet creation with the same
compiled model. It does not represent warmed pooled contexts. The first comparison
uses separate processes and includes provider/model initialization. Timings vary;
the allocation reduction is the more stable result.

No schema or stored-data change is part of this optimization. EF's pending-model
check reports no changes since the last migration.

## NativeAOT boundary

The compiled model is a prerequisite, not proof that every consumer query supports
NativeAOT. Queries live in the API, Logic and tools, and require their own query
precompilation. Conditional IQueryable composition remains a limitation in EF's
experimental pipeline; the API has not been switched to NativeAOT.

A separate native diagnostic executable successfully accessed all 68 DbSets and
read Music/Client projections and an IAsyncEnumerable stream from SQL Server with
`RuntimeFeature.IsDynamicCodeSupported == false`. A whole-Client materialization
query instead exposed an EF 10.0.5 generated-interceptor C# syntax error. Generated
code was not patched to hide that failure. EF/SqlClient trimming/AOT warnings also
remain. These limitations must be rechecked before a production AOT rollout.

The historical .NET 10 dependency graph additionally reported NuGet audit warnings
for System.Security.Cryptography.Pkcs 9.0.4 and the installed ILCompiler 10.0.9.
Package versions and security policy were not changed as part of that model
optimization. NuGet audit was disabled only in the temporary query-precompilation
diagnostic process to separate its workspace-warning issue from runtime behavior;
it remains enabled in project builds.

References: [EF compiled models and performance](https://learn.microsoft.com/en-us/ef/core/performance/advanced-performance-topics),
[EF MSBuild integration](https://learn.microsoft.com/en-us/ef/core/cli/msbuild),
[NativeAOT limitations](https://learn.microsoft.com/en-us/ef/core/performance/nativeaot-and-precompiled-queries).

## Separate mapping observation

`MusicCommentConfiguration` already exists but is not registered in
`OnModelCreating`. Applying it would change text length, delete behavior and an
index. That schema/behavior change was not folded into these runtime optimizations.
