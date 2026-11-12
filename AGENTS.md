# Mizon database development requirements

Read [the shared workflow](docs/ai/COLLABORATION.md), [project map](docs/ai/PROJECT.md)
and [handoff](docs/ai/HANDOFF.md) before editing.

- Preserve entity/configuration/naming conventions and relational ownership.
- Standing user requirement, effective 2026-11-12: every future new or changed
  interactive feature/page must also support Xbox controllers. Coordinate the
  Windows client for schema work supporting such features; follow the
  [shared controller requirements](docs/ai/COLLABORATION.md#xbox-controller-support-is-part-of-interactive-features).
  Preserve shared operations, native UI/accessibility/localization and cleanup;
  include meaningful input/state/lifecycle checks and report unverified hardware
  and visual cases. Existing pages are not presumed covered.
- Model schema with EF code-first migrations. Runtime inserts/updates and business
  decisions belong in the sibling Mizon.Server.Logic/Operations project.
- Do not add SQL business logic, invent historical records/backfills or apply
  migrations/seed data to a real database without task authorization.
- Model type catalogs as lookup tables like MusicGenreType, following existing
  reference-data conventions; do not silently replace them with persisted enums.
- Keep explicit projections/readable split queries in consuming operations and
  separate AND predicates into Where calls. Never parallelize one DbContext.
- Keep generated compiled-model files under obj. Never edit generated EF code to
  hide a failure or claim that a compiled model makes every query NativeAOT-safe.
- Preserve all SaveChanges overload semantics, metadata, tracking, cancellation,
  context pooling and disposal. Run the model regression checks when changing them.
- User-facing feature changes must coordinate shared API/SDK and scoped Windows MCP
  state/actions using the existing business operation. Read the Windows
  Mcp/DEVELOPMENT.md; its current coverage is authentication, appearance, declared
  navigation and taskbar pinning, not all domain operations.
- MCP approval belongs to the user inside Mizon. New domains need independent,
  default-denied scopes; tools/tests cannot approve themselves. Use synthetic
  writes for tests unless actual data changes are part of the user's task.
- Do not run Windows UI automation unless explicitly requested.

## Standing publication and collaboration instruction

After every completed task, make a precise task-scoped commit and push it to GitHub
without asking again for routine permission. Follow COLLABORATION.md for validation,
cross-repository commits and failure reporting. Do not include another agent's
unfinished edits by default. Use separate worktrees/branches for concurrent agents,
coordinate file ownership and preserve shared history; never force-push over others.
