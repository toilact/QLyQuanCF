# NuGet package upgrade assessment

_Mode: **quick assessment** — package API diffs only; no per-project source scan was run._

## Recommended versions

- **Microsoft.EntityFrameworkCore.Design**: **10.0.14** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.SqlServer**: **10.0.14** (unified across 1 project(s)).
- **Microsoft.EntityFrameworkCore.Tools**: **10.0.14** (unified across 1 project(s)).

## Public API changes

> **Types moved (namespace changed) are not removals.** A moved type keeps its name and members;
> the fix is a `using`-directive change, not a rewrite. Do not treat a moved type as deleted.

- **Microsoft.EntityFrameworkCore.SqlServer**: 3 type(s) removed, 36 member(s) removed — see [`apidiff/Microsoft.EntityFrameworkCore.SqlServer.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.SqlServer.apidiff.md).
- **Microsoft.EntityFrameworkCore.Tools**: no source-breaking public API changes detected — see [`apidiff/Microsoft.EntityFrameworkCore.Tools.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Tools.apidiff.md).
- **Microsoft.EntityFrameworkCore.Design**: 1 type(s) removed, 17 member(s) removed — see [`apidiff/Microsoft.EntityFrameworkCore.Design.apidiff.md`](apidiff/Microsoft.EntityFrameworkCore.Design.apidiff.md).

## Breaking-change findings

- Version divergence findings (Pkg.0003): 0
- Requested-version-unsupported findings (Pkg.0002): 0

- Quick mode does not scan source, so there are no per-line `PkgApi` usage findings. Review the
  per-package API diffs above and rely on build errors during execution to pinpoint affected code.
- A full code scan can locate the exact source location of every breaking-change usage across the repo.
  It is opt-in and slower — re-run the assessment with `fullScan=true` only if the user requests it.

## Next steps

1. Proceed to planning to triage the API changes above and plan the code fixes (if any).

