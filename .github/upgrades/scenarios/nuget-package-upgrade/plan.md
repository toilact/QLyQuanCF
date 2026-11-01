# NuGet Package Upgrade Plan

## Overview

**Target**: Upgrade the `CoffeeShopManagement` project from EF Core 8.0.11 to the stable EF Core 10.0.14 package family.
**Scope**: One .NET 10 Windows Forms project with SQL Server provider, EF Core Tools, and EF Core Design packages.

## Tasks

### 01-upgrade-ef-core: Upgrade EF Core package family

Update `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`, and `Microsoft.EntityFrameworkCore.Design` in `CoffeeShopManagement.csproj` from `8.0.11` to `10.0.14`. The assessment found no version divergence and no source usage of the removed internal APIs listed in the SQL Server and Design API diffs, so handle those findings as not applicable to this application code. Validate migrations tooling, restore, build, and tests after the package update.

**Done when**: All three EF Core package references resolve to `10.0.14`; the project restores and builds with zero warnings/errors; EF Core migrations tooling can load the existing `AppDbContext`; existing tests, if any, pass; `Data/DbInitializer.cs` remains compatible with `Database.Migrate()`.
