# 2026-11-25 — Account device session persistence

- Status: implementation verified in an isolated SQL Server database.
- Owner: Codex Windows/server. Branch: codex/device-sessions.
- Scope: ClientSession configuration and the Client/ClientSession entities and migrations.
- Related repositories: Mizon.Server.API, Mizon.API.DotNet, Mizon.Windows and native Apple/Android clients.

The two migrations add the account's inactivity setting, the session recognition state,
and an index for active sessions ordered by activity. A null or zero inactivity value
means no expiry policy was selected. Existing sessions initially have confirmation
pending set to false. No session rows are seeded and no migration runs at app startup
for this feature.

The API diagnostics exercised the model against a generated scratch SQL Server
database. Apply the two migrations through the normal database deployment process
before starting the matching API. The running development database was untouched.
