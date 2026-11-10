# 2026-11-10 repository synchronization

- Status: source and documentation complete; publication is represented by this branch's Git history.
- Owner: Codex, coordinated by the user.
- Repository: Shahesmaeili/Mizon.Database, branch main.
- Base: existing unversioned source, no previous Git commit.
- Scope: publish all current database source and establish durable shared AI instructions.

## Result

The outer database directory is the Git root. Entities, configurations, migrations,
the solution and regression project are included. Generated EF models, build output,
IDE state and local database/credential files are ignored. No schema/data changes
or migration application were performed during publication.

AGENTS.md, CLAUDE.md, Copilot instructions and docs/ai provide one shared development
workflow, architecture map, handoff and task template. Future tasks require precise
task-scoped commits and pushes; parallel agents use isolated worktrees.

## Validation

- dotnet run --project Mizon.Database.Tests -c Release -p:Platform=x64: 40 passed.
- No SQL connection, database writes, migration, deployment or UI automation.
- Existing dependency advisories and EF consumer NativeAOT limits remain documented.

## Related publication

The matching Server, .NET SDK and Windows snapshots use the same task ID.
The server repository's task note records the cross-repository commit hashes.
Use git log for this note to identify its containing commit.
