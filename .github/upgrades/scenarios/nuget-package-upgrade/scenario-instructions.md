# NuGet Package Upgrade

## Strategy
Upgrade the EF Core package family together to stable 10.0, then resolve API/build issues.

## Preferences
- **Flow Mode**: Automatic
- **Commit Strategy**: After Each Task
- **Target Packages**: Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools, Microsoft.EntityFrameworkCore.Design
- **Target Version**: 10.0
- **Full Semantic Scan**: Disabled unless breaking-change locations require it

## Source Control
- **Source Branch**: main
- **Working Branch**: upgrade-nuget-ef-core-10
- **Commit Strategy**: After Each Task
- **Branch Sync**: Disabled

## Decisions
- Existing uncommitted changes were committed before the upgrade branch was created.
- Keep `Data/DbInitializer.cs` unchanged unless EF Core 10 compatibility requires a code fix.
- **Resolved EF Core versions**: 10.0.14 for SqlServer, Tools, and Design; unified across the scoped project.
- **Package management**: No `Directory.Packages.props` was found; update package versions directly in `CoffeeShopManagement.csproj`.
- **Breaking-change handling**: Migrate only if the build identifies an application call site; the assessed removed APIs are internal EF Core provider/design APIs and no matching application usages were found.
