# 2Hearts1Goal

Dating platform starter built as a modular monolith on `.NET 10` Web API with `SQL Server` and clean project boundaries for future microservice extraction.

## Stack decisions

- Backend: `.NET 10` Web API
- Data: `SQL Server` via `EF Core`
- Architecture: modular monolith split into projects
- Frontend: backend is API-first and can support Angular, React, or mobile clients

As of March 25, 2026, `.NET 10` is the latest stable release and it is an LTS release. SQL Server keeps the path open to Azure SQL and AWS RDS for SQL Server with minimal backend friction.

## Solution layout

- `src/2Hearts1Goal.Api`: monolith host and shared API composition root
- `src/2Hearts1Goal.Application`: current shared application contracts for the core profile slice
- `src/2Hearts1Goal.Domain`: shared entities, value objects, and business rules
- `src/2Hearts1Goal.Infrastructure`: shared EF Core persistence and external concerns
- `src/Modules/Accounts`: grouped `Presentation`, `Application`, and `Infrastructure` projects
- `src/Modules/Subscriptions`: grouped `Presentation`, `Application`, and `Infrastructure` projects
- `src/Modules/Matchmaking`: grouped `Presentation`, `Application`, and `Infrastructure` projects
- `src/Modules/Messaging`: grouped `Presentation`, `Application`, and `Infrastructure` projects
- `src/Modules/Search`: grouped `Presentation`, `Application`, and `Infrastructure` projects
- `src/Modules/Users`: grouped `Presentation`, `Application`, and `Infrastructure` projects
- `docs/architecture.md`: architectural rationale and future split guidance

## Local setup

1. Install the `.NET 10 SDK`.
2. Install SQL Server Developer Edition or LocalDB.
3. Restore packages:

```powershell
dotnet restore
```

4. Create the first migration:

```powershell
dotnet ef migrations add InitialCreate --project .\src\2Hearts1Goal.Infrastructure --startup-project .\src\2Hearts1Goal.Api
```

5. Apply the database:

```powershell
dotnet ef database update --project .\src\2Hearts1Goal.Infrastructure --startup-project .\src\2Hearts1Goal.Api
```

6. Run the API:

```powershell
dotnet run --project .\src\2Hearts1Goal.Api
```

## API endpoints

- `GET /api/meta/info`
- `GET /api/profiles`
- `POST /api/profiles`
- `POST /api/accounts/register`
- `POST /api/accounts/login`
- `POST /api/users`
- `GET /api/users/by-account/{accountId}`
- `PUT /api/users/settings`
- `GET /health`

## Accounts module notes

The Accounts module now has its own layered slice for:

- credential validation
- password hashing
- session token issuance using `GUID`
- account registration/login endpoints
- auth-focused account identity only

The credential/session store is now wired to SQL Server through EF Core. The next operational step is creating and applying a migration for the `Accounts` and `AccountSessions` tables.

## Users module notes

The Users module is now the home for app-level identity and settings such as:

- display name
- birth date
- time zone
- marketing preferences
- discoverability
- push-notification preferences

This keeps `Accounts` focused on AuthN/AuthZ and keeps product/user settings out of the security model.

The Users module is also wired to SQL Server now. The next operational step is creating and applying a migration for the `Users` table and its `Account -> User` one-to-one relationship.

## Angular guidance

Angular is a reasonable choice if you want a structured SPA for authenticated product flows. For the public-facing acquisition side of a dating product, Angular is usually not the strongest default if SEO and rapid marketing iteration matter a lot. My recommendation is:

- keep this backend API-first now
- choose Angular only if your frontend team prefers it and the product is primarily authenticated-app driven
- consider React with Next.js if public growth pages are a first-class business concern

If you still want Angular, the current supported line is Angular `21`, with Angular `20` also in LTS as of March 25, 2026.
