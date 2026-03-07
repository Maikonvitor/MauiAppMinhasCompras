# MauiAppMinhasCompras .NET 10.0 Upgrade Tasks

## Overview

This document tracks the execution of the MauiAppMinhasCompras upgrade from .NET 8.0 to .NET 10.0 (LTS). The single MAUI project will be upgraded atomically across all target platforms, followed by comprehensive platform testing.

**Progress**: 1/4 tasks complete (25%) ![0%](https://progress-bar.xyz/25)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-03-01 22:40)*
**References**: Plan §Phase 0 Prerequisites

- [✓] (1) Verify .NET 10 SDK installed per Plan §Prerequisites
- [✓] (2) .NET 10 SDK version confirmed (**Verify**)
- [✓] (3) Verify .NET MAUI 10 workload installed per Plan §Prerequisites
- [✓] (4) MAUI 10 workload present in workload list (**Verify**)

---

### [▶] TASK-002: Atomic framework and package upgrade
**References**: Plan §Phase 1 Atomic Upgrade, Plan §Project-by-Project Plans, Plan §Package Update Reference

- [✓] (1) Update TargetFrameworks property in MauiAppMinhasCompras\MauiAppMinhasCompras.csproj per Plan §Technology/Framework Update (net8.0-* → net10.0-*)
- [✓] (2) All target frameworks updated to net10.0 variants (**Verify**)
- [✓] (3) Update Microsoft.Extensions.Logging.Debug package reference from 8.0.0 to 10.0.3 per Plan §Package/Dependency Updates
- [✓] (4) Package reference updated to version 10.0.3 (**Verify**)
- [▶] (5) Restore all dependencies for all target frameworks
- [ ] (6) All dependencies restored successfully (**Verify**)
- [ ] (7) Build solution for all target frameworks and fix any compilation errors per Plan §Breaking Changes Catalog
- [ ] (8) Solution builds with 0 errors for all target frameworks (**Verify**)

---

### [ ] TASK-003: Platform testing and validation
**References**: Plan §Phase 2 Validation, Plan §Testing & Validation Strategy

- [ ] (1) Deploy and test application on Android platform per Plan §Android Testing
- [ ] (2) Deploy and test application on iOS platform per Plan §iOS Testing
- [ ] (3) Deploy and test application on Mac Catalyst platform per Plan §Mac Catalyst Testing
- [ ] (4) Deploy and test application on Windows platform per Plan §Windows Testing
- [ ] (5) All platforms launch successfully with core functionality working (**Verify**)

---

### [ ] TASK-004: Final commit
**References**: Plan §Source Control Strategy

- [ ] (1) Commit all changes with message: "Upgrade solution to .NET 10.0 - Update TargetFrameworks to net10.0-*, Update Microsoft.Extensions.Logging.Debug to 10.0.3"

---

using SQLite;

public class Produto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Descricao { get; set; }
    public double Quantidade { get; set; }
    public double Preco { get; set; }
}

public class SQLiteDatabaseHelper
{
    readonly SQLiteAsyncConnection _conn;

    public SQLiteDatabaseHelper(string path) { ... }  // Creates connection + table
    public Task<int> Insert(Produto p) { ... }
    public Task<List<Produto>> Update(Produto p) { ... }  // Raw SQL UPDATE
    public Task<int> Delete(int id) { ... }
    public Task<List<Produto>> GetAll() { ... }
    public Task<List<Produto>> Search(string q) { ... }   // ⚠️ Has bugs
}

<PackageReference Include="sqlite-net-pcl" Version="1.9.172" />




