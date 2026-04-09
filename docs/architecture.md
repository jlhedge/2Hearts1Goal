# Architecture Notes

## Why this structure

This repo is set up as a modular monolith:

- `2Hearts1Goal.Api`: HTTP layer only
- `2Hearts1Goal.Application`: use-case contracts and orchestration
- `2Hearts1Goal.Domain`: core dating business model
- `2Hearts1Goal.Infrastructure`: EF Core, SQL Server, and external integrations

That gives us strong separation of responsibilities today without paying the operational tax of microservices too early.

## How this supports future extraction

These boundaries make later service extraction easier:

- domain logic is not coupled to ASP.NET
- application contracts are not coupled to SQL Server
- infrastructure is behind interfaces
- the API is thin and can later become a gateway or a dedicated service endpoint

When we split services later, likely candidates are:

- identity and auth
- profile management
- matching and recommendation
- messaging
- billing/subscriptions
- notifications

The repo now groups future service candidates under `src/Modules/<Area>/` and gives each one its own:

- `Presentation`
- `Application`
- `Infrastructure`

That gives us a microservice-like internal boundary while still deploying as one monolith today.

The first module fleshed out further is `Accounts`, which now includes:

- password policy validation
- PBKDF2 password hashing
- GUID-based session token issuance
- dedicated register/login endpoints

Accounts and Users are now wired for SQL-backed persistence through the shared EF Core context while keeping their store implementations in their own module infrastructure layers.

## Account vs user vs profile

These are now distinct concepts in the design:

- `Account`: credentials, sessions, authentication, authorization
- `User`: internal app identity and private settings
- `Profile`: dating-facing profile data used for discovery and matching

Recommended relationship:

- `Account` 1-to-1 `User`
- `User` 1-to-1 or 1-to-many `Profile`

That separation keeps security concerns isolated from product concerns and gives us room to evolve profile behavior independently from login/session behavior.

## Database direction

Starting with SQL Server is a strong fit because it keeps the local developer experience familiar and translates cleanly to:

- Azure SQL
- AWS RDS for SQL Server

If we later move to PostgreSQL or another engine, most of the change stays inside `Infrastructure`.

## Frontend note

Angular is a solid choice when you want:

- a strongly structured SPA
- long-lived maintainability
- a team comfortable with TypeScript and convention-driven architecture

For a consumer dating product, Angular is not automatically the best choice. If SEO-heavy marketing pages, rapid experimentation, and broader hiring are top priorities, React with Next.js is often the stronger default. Because this repo is API-first, we can defer that decision without reworking the backend.
