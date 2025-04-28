# CafeEmployee Backend - Clean Architecture (.NET Core)

This repository contains the backend for the **CafeEmployee** application, built with ASP.NET Core and following Clean Architecture principles.

The focus is to ensure the codebase remains organized, scalable, and easy to maintain — while also being pragmatic to deliver core functionality efficiently under time and resource constraints (solo development).

---

## Development Approach

Because of time constraints and solo development, the design thinking for this project emphasizes:

- **Core functionality first**  
  - Priority is placed on fulfilling user requirements and delivering the main features early.  
  - Focus is maintained to avoid over-engineering and prevent deviation from user requirements.  
  - Enhancements, optimizations, refactoring and extras are considered secondary and only implemented if truly needed.

- **Testing (not yet implemented)**  

- **Unified Error Handling**  
  Both server-side errors (500) and validation errors (400) are handled consistently, returning a unified `{ error, message }` format to simplify frontend error handling.

- **Logging (partially implemented)**  
  Basic error logging at the API level is implemented through global error handling (including both system errors and manually thrown exceptions).  

---

## Project Structure

- **CafeEmployee.API**  
  - Entry point of the application (controllers, middleware, startup configurations)

- **CafeEmployee.Core**  
  - Domain entities, business logic, and application contracts (interfaces, DTOs)

- **CafeEmployee.Infrastructure**  
  - Database context, repository implementations, and third-party integrations (e.g., EF Core)

---

## Tech Stack and Patterns Used

- **ASP.NET Core** 
- **Entity Framework Core (EF Core)** 
- **PostgreSQL** 
- **Autofac** 
- **Clean Architecture** 
- **CQRS (Command Query Responsibility Segregation)** 
- **MediatR** 
- **KISS Principle (Keep It Simple, Stupid)** 

---

## Prerequisites

- .NET 9 SDK (version 9.0.203 or later)
- EF Core CLI Tools (`dotnet tool install --global dotnet-ef`)
- PostgreSQL database server running locally or remotely
- (Optional) PgAdmin or any PostgreSQL GUI client to inspect the database

---

## Development Setup

After cloning the repository:

1. Navigate to the `/cafe-employee-backend` folder:
   

2. Restore all NuGet packages:
    ```bash
    dotnet restore
    ```
  
3. Update your database connection string:
    - File: `CafeEmployee.API/appsettings.json`
    - Modify the `ConnectionStrings` section to match your local PostgreSQL server.

4. Apply the database migrations (if the database does not exist yet):
    ```bash
    dotnet ef database update --project src/CafeEmployee.Infrastructure --startup-project src/CafeEmployee.API
    ```

5. Run the API project:
    ```bash
    dotnet run --project src/CafeEmployee.API
    ```


