# ASP.NET Core Web API Learning Labs (.NET 10)

## Objective
Learn and build RESTful Web APIs step-by-step using ASP.NET Core (.NET 10), progressing from basic routing and CRUD operations to Dependency Injection, Unit Testing, and Database Integration with Entity Framework Core.

## Technologies
- C#
- ASP.NET Core 10
- Entity Framework Core 10 (SQLite)
- xUnit (Unit Testing)
- Visual Studio Code
- Postman / Swagger

---

## Labs Overview

| Lab | Topic | Key Focus | Status |
|---|---|---|---|
| **Lab 01** | My First ASP.NET Core Web API | Project setup, Controllers, Routing, and HTTP GET | Completed |
| **Lab 02** | CRUD Web API | Full RESTful CRUD endpoints (`GET`, `POST`, `PUT`, `DELETE`) with HTTP status codes | Completed |
| **Lab 03** | Dependency Injection & Testing | Separation of concerns, DI Lifetimes (`Transient`, `Scoped`, `Singleton`), Multiple Services, and xUnit testing with Fake Services | Completed |
| **Lab 04** | Database Integration | Persistent storage with EF Core, SQLite, Migrations, Seed Data, and `Scoped` DbContext | Completed |

---

## Topics Covered
- **API Fundamentals:** Project setup, Controllers, Attribute Routing, JSON serialization, and HTTP status codes (`200`, `201`, `204`, `400`, `404`).
- **Software Architecture:** Decoupling business logic from Controllers using Service Interfaces (`IEmployeeService`, `IDepartmentService`).
- **Dependency Injection (DI):** Service registration, Constructor Injection, Multiple Service Injection, and understanding `Transient`, `Scoped`, and `Singleton` lifetimes.
- **Automated Testing:** Writing isolated Unit Tests using xUnit and Fake Services (AAA pattern).
- **Database Persistence:** Configuring `AppDbContext`, EF Core Migrations, Seed Data, and connecting SQLite via `Scoped` services.

---

## Implemented Endpoints

### Lab 01 — Basics
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/hello` | Returns a greeting message |
| GET | `/api/student` | Returns student information |

### Lab 02 – Lab 04 — Employee & Department API
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/employee` | Retrieves all employees |
| GET | `/api/employee/{id}` | Retrieves a specific employee by ID |
| GET | `/api/employee/overview` | Retrieves combined company overview (Employees & Departments) |
| POST | `/api/employee` | Creates a new employee |
| PUT | `/api/employee/{id}` | Updates an existing employee |
| DELETE | `/api/employee/{id}` | Deletes an employee |
| GET | `/api/diagnostics/lifetimes` | Compares `Transient`, `Scoped`, and `Singleton` instance IDs |

---

## Sample Responses

### GET /api/student
```json
{
  "name": "Nawapon Somruang",
  "major": "Software Engineering",
  "university": "Chiang Mai University"
}

GET /api/employee/overview
{
  "totalEmployees": 2,
  "totalDepartments": 3,
  "departments": [
    {
      "id": 1,
      "name": "Engineering",
      "location": "Building A"
    }
  ],
  "employees": [
    {
      "id": 1,
      "name": "John",
      "position": "Developer"
    }
  ]
}
