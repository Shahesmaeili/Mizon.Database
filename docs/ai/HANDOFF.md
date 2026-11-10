# Database handoff — 2026-11-10

The existing local EF source was not under Git despite being referenced by the
server solution. This publication initializes the outer Mizon.Database directory
as its own repository and includes the model, migrations, regression project and
AI collaboration documentation. It does not alter tables or stored data.

Validation in this publication: Release/x64 regression runner passed all 40 checks,
without a SQL connection. See Mizon.Database/README.md for earlier compiled-model
and NativeAOT evidence and known consumer-query limitations; those historical
performance results were not remeasured here.

Known limits:
- Full EF-consuming server NativeAOT support is not established.
- Existing dependency/security warnings remain visible; no dependency upgrade was
  bundled into repository setup.
- No database migration, backfill, seed, export or import was executed.
- The design-time factory uses local integrated Windows authentication; configure
  the correct environment before any intentional migration command.

Next tasks should use a separate worktree, preserve current migrations and coordinate
schema/DTO/operation/UI/MCP changes across the related repositories.
