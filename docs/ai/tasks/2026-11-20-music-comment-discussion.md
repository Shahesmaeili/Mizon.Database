# Music comment discussion schema

- Status: complete
- Owner: Codex
- Date: 2026-11-20
- Repository and branch: Mizon.Database, `codex/music-comment-discussion`
- Base commit: `4d03d94`
- Related repositories: Mizon.Server.API, Mizon.API.DotNet, Mizon.Windows
- Owned areas: comment entities, configurations and the additive schema migration.

## Request and acceptance criteria

Store nested replies, posting platform, like/dislike and entity tags for track
comments. Existing comments retain their content, author and optional timestamp.

## Implementation and decisions

A composite foreign key keeps replies on their parent’s track. Each account can
have one vote per comment. A tag references one artist, account, track or video.
Historical comments keep an unknown posting platform. Application writes stay
in Server.Logic. The migration contains schema operations and no data backfill.

## Validation

| Command / environment | Result | Limits |
| --- | --- | --- |
| Mizon.Database.Tests, .NET 11 | 41 checks passed | Compiled-model and context checks |
| Server ApiDiagnostics `--music-discussion-sql` | Migration up, down, up and queries passed | Temporary SQL Server database with synthetic data |

## Handoff

Apply `20261120145502_AddMusicCommentDiscussion` through the normal migration
process before using the new API on a shared database. The task applied it only
to a disposable fixture. EF's existing NativeAOT warning remains.

## Publication

Target branch: `main`.
