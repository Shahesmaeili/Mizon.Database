# Database project map

This repository includes Mizon.Database/ (EF Core model) and
Mizon.Database.Tests/ (console regression checks). Keep this outer directory as
the Git root so sibling Server project references and tests resolve correctly.

## Model ownership

- Mizon.Database/Entities: relational entities and lookup-table types.
- Mizon.Database/Configurations: EF mapping, constraints, indexes and relationships.
- Mizon.Database/Migrations: code-first migration history and snapshot.
- MizonDatabaseContext: DbSets, metadata stamping and SaveChanges overloads.
- MizonDatabaseContextFactory: design-time SQL Server context for EF tools.

Current domains include clients/persons, music/media/files/lyrics, playlists,
story widgets and activity, follow/privacy history, moods and featured media.
Inspect the actual model; table existence does not imply complete server/UI behavior.

All runtime writes and decisions belong in Mizon.Server.Logic/Operations in the
server repository. Do not populate histories with invented baseline dates or add
raw SQL business behavior during a schema-only task.

## .NET 10 and NativeAOT

EF Core 10.0.5 compiled-model generation runs during real builds; sources stay under
obj per configuration/platform. GlobalUsings remains small. Preserve project
targets that ensure model generation uses the current compiled assembly.

IsAotCompatible enables analysis. EF consumer queries need separate precompilation;
the complete API is not certified NativeAOT. Do not patch generated interceptors
or suppress broad warnings to pretend otherwise. See the detailed existing
[model/performance README](../../Mizon.Database/README.md).

## Build and safe tests

From this repository root:

~~~powershell
dotnet build Mizon.Database/Mizon.Database.csproj -c Release -p:Platform=x64
dotnet run --project Mizon.Database.Tests -c Release -p:Platform=x64
~~~

Tests intercept saves and open no SQL connections. They cover compiled-model
selection, DbSets, context pooling/reset, tracking/metadata, save overloads,
interceptors/events, cancellation and error propagation.

Migration creation and database update are different operations. For a schema
task inspect existing migrations, generate the intended migration using EF tooling,
review its operations and model snapshot; apply it only when that task authorizes
the target database change. A build never authorizes a live update.

## Related repositories

- Mizon.Server.API: runtime operations and HTTP/SignalR integration.
- Mizon.API.DotNet (folder Mizon.API): shared client contracts and SDK.
- Mizon.Windows: UI and separately permissioned MCP adapter.

Use public GUID IDs in outward-facing contracts where the existing API does so;
do not confuse them with indexed database primary keys.
Read [COLLABORATION.md](COLLABORATION.md) and update [HANDOFF.md](HANDOFF.md)
and a task note when behavior/schema decisions change.
