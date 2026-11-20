# Restore track metadata on the local development database

- Owner: Codex
- Database base: `6d427c0`
- API release dependency: `6aedf7a`

The video lookup in the production track detail operation failed with SQL Server
error 208 when the `MusicVideos` table was absent. The failure blocked the common
response containing the track title, genres, and other metadata.

EF Core 11 identified `20261119232657_AddTrackMusicVideos` as the only pending
migration on the local `Mizon` database. The existing migration creates the table,
its keys and indexes. Applying it added no video records, and the existing music
and genre row counts matched before and after. The migration is now recorded as
applied.

An isolated SELECT-only diagnostic called the actual track detail operation from
the running API's build. It reproduced the missing-table error before migration.
After migration, it verified that five existing tracks without linked videos
returned their stored titles and genre lists.

When deploying the linked-video API to another database, apply this migration
before starting that API version. An already open track page needs a fresh
navigation to request the repaired data. The Windows UI was not automated.
