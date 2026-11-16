# Artist profile schema

- Owner: Codex
- Branch: `codex/person-profile`, base `88ef055`
- Owns: Person mapping, credit index, migration and model snapshot

Migration `20261116045403_AddPersonProfileMediaAndClientLink` adds optional
`CoverMediaId`, `ModelMediaId` and unique nullable `LinkedClientId` to Persons.
`ProfileMediaId` remains the artist photograph. Cover and model reuse Media.
An official link identifies the Client account whose outgoing following count
can be shown. A private linked account is hidden from other viewers. The
migration replaces the single-column person credit index with `(PersonId, MusicId)`.

No artist artwork, account links or follow history are seeded by the migration.
Follow writes and reference-catalog creation run through the server operation.
The snapshot matches the current model. Database regression checks passed
(40/40). The server harness exercised Up/Down/Up in disposable SQL Server from
the prior model because the older history assumes a starting schema. The live
database was not changed.
