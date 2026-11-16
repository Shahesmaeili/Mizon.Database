# Featured person catalog schema

- Owner: Codex, branch `codex/featured-persons`.
- Base: `a377c8a`.
- Owned paths: the FeaturedPerson entities/configurations, DbContext, migration/snapshot and the MusicPlay covering index.

`FeaturedPersonTypes` identifies each catalog by code. `FeaturedPersons` stores the
Person reference, unique positive position per type, optional accent color and model
presentation fields. The same person can belong to multiple catalogs. Model,
cover and portrait assets use the existing Person media links.

The migration is schema-only. Type and editorial sample inserts are explicit
.NET business operations in the API repository. The music/date index covers the
client ID for aggregate counts and replaces the old music-only index.

Verified no pending model changes, Up/Down/Up on an isolated SQL Server schema
and migration of the developer database. See the coordinated API and Windows notes
for runtime checks.
