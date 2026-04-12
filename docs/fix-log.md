# Fix Log

Tracks build and setup issues fixed while getting the repo into a runnable state.

## 2026-04-11

### Summary

- Installed the required `.NET 10` SDK.
- Fixed project reference and framework reference issues that blocked compilation.
- Corrected a domain-model initialization bug.
- Verified the full solution with `dotnet restore` and `dotnet build`.

### Fixes

#### 1. SDK mismatch

- Symptom: local `dotnet` commands failed because the repo targets `.NET 10.0.100` in [global.json](../global.json).
- Cause: the machine only had SDKs through `.NET 8` installed.
- Fix: installed and verified `.NET SDK 10.0.201`.
- Verification: `dotnet --version` resolved to `10.0.201`.

#### 2. `Profile` default value construction error

- Symptom: build failed because `Profile` tried to call an inaccessible `MatchPreferences()` constructor.
- Cause: [Profile.cs](../src/2Hearts1Goal.Domain/Entities/Profile.cs) used `new()` while [MatchPreferences.cs](../src/2Hearts1Goal.Domain/ValueObjects/MatchPreferences.cs) exposes only a private parameterless constructor.
- Fix: replaced the default initialization with an explicit valid `MatchPreferences` instance.
- Verification: the `2Hearts1Goal.Domain` project now builds successfully.

#### 3. Missing DI framework references in module infrastructure projects

- Symptom: multiple projects failed to resolve `Microsoft.Extensions.DependencyInjection` and `IServiceCollection`.
- Cause: the `Matchmaking`, `Messaging`, `Search`, and `Subscriptions` infrastructure projects used DI extension classes without the required framework reference.
- Fix: added `<FrameworkReference Include="Microsoft.AspNetCore.App" />` to the affected infrastructure project files.
- Verification: those infrastructure projects now compile during full solution build.

#### 4. Missing framework/package references in application and presentation projects

- Symptom: shared application and several presentation projects failed to resolve `IServiceCollection`, `Microsoft.EntityFrameworkCore`, and `DbSet<T>`.
- Cause: the relevant projects referenced ASP.NET Core / EF Core abstractions without declaring the necessary framework or package references.
- Fix: added the needed ASP.NET Core framework references and the EF Core package reference to the affected project files.
- Verification: `dotnet restore` succeeded after the reference updates, and the dependent projects compiled.

### Current Status

- `dotnet restore`: passing
- `dotnet build`: passing
- Remaining compile-time reference errors: none found from CLI build

### Notes

- `2Hearts1Goal.sln` was already modified before this fix pass.
- `src/2Hearts1Goal.Api/Properties/launchSettings.json` was already present as an untracked file before this fix pass.
