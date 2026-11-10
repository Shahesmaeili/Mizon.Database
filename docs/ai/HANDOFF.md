# Database handoff — 2026-11-10

## .NET 11 migration

Both projects target net11.0, EF package family is 11.0.0 and global.json selects
SDK11.0.100. Compiled-model generation uses the EF11 stage properties directly;
the obsolete EFOptimizeContext flag was removed. No entities, migrations or stored
data changed. The existing local SQL database supports EF11's default compatibility.

Validation for this migration:
- .NET10 baseline: SDK10 Release/x64 build and all 40 regression checks passed.
- .NET11 candidate: SDK11 Release/x64 compiled-model build and all 40 checks passed.
- Actual .NET11 win-x64 NativeAOT publish and all 40 executable checks passed.
- The regression checks opened no SQL connections. No schema/data writes occurred.
- Identical opt-in context benchmark source was archived with both runtime builds;
  root coordinates serial measurements and the cross-repository result table.

See [the task record](tasks/2026-11-10-net11-upgrade.md) for artifact locations and
[the model README](../../Mizon.Database/README.md) for benchmark methodology.
Earlier November8 .NET10 optimization measurements remain historical comparisons,
not .NET10-versus11 results.

Known limits:
- Full EF-consuming server NativeAOT support is not established.
- EF/SqlClient AOT and trimming warnings remain visible. A successful model/save
  regression executable does not prove every dynamically composed query supports AOT.
- No database migration, backfill, seed, export or import was executed.
- The design-time factory uses local integrated Windows authentication; configure
  the correct environment before any intentional migration command.

Integration/publication is coordinated by the root agent with the Server, SDK and
Windows upgrades. Preserve current migrations and coordinate future model changes.
