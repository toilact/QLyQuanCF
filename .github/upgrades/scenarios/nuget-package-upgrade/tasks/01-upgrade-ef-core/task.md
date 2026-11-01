# 01-upgrade-ef-core: Upgrade EF Core package family

Update `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`, and `Microsoft.EntityFrameworkCore.Design` in `CoffeeShopManagement.csproj` from `8.0.11` to `10.0.14`. The assessment found no version divergence and no source usage of the removed internal APIs listed in the SQL Server and Design API diffs, so handle those findings as not applicable to this application code. Validate migrations tooling, restore, build, and tests after the package update.

## Research findings

- Affected project: `CoffeeShopManagement.csproj`, SDK-style WinForms project targeting `net10.0-windows`.
- `get_project_dependencies` found standard per-project `PackageReference` management; no Central Package Management or imported package-version file is present.
- Current EF Core packages are all `8.0.11`; the assessment resolved a unified stable target of `10.0.14` for all three requested packages.
- The quick API diff lists removed internal SQL Server and Design APIs, but repository search found no application references to those internal namespaces/types. `Data/DbInitializer.cs` uses public `Database.Migrate()` and should remain unchanged.
- Because the project is WinForms, targets `net10.0-windows`, and includes designer `.resx` resources, use Visual Studio `MSBuild.exe /restore` for validation rather than relying only on portable `dotnet build`.

**Done when**: All three EF Core package references resolve to `10.0.14`; the project restores and builds with zero warnings/errors; EF Core migrations tooling can load the existing `AppDbContext`; existing tests, if any, pass; `Data/DbInitializer.cs` remains compatible with `Database.Migrate()`.
