# Lab 03: Dependency Injection & Service Layer

## Overview

This lab focuses on refactoring the Employee Management REST API using Dependency Injection (DI) and the Service Layer pattern in ASP.NET Core Web API.

The purpose is to separate business logic from the Controller by introducing an Interface and a Service implementation. The application uses Constructor Injection to provide the service dependency and `AddScoped()` to register it in the Dependency Injection container.

Employee data is stored in an in-memory `List<Employee>` without using a database.

## Technologies

- C#
- ASP.NET Core Web API
- .NET 10
- Dependency Injection
- Service Layer Pattern
- REST API
- Postman
- Visual Studio / Visual Studio Code

## Project Structure

```text
Lab-03-Dependency-Injection/
├── README.md
└── EmployeeAPI/
    ├── Controllers/
    │   └── EmployeeController.cs
    ├── Models/
    │   └── Employee.cs
    ├── Services/
    │   ├── IEmployeeService.cs
    │   └── EmployeeService.cs
    ├── Program.cs
    └── EmployeeAPI.csproj
```

## Key Concepts

### 1. Interface

`IEmployeeService` defines the contract for employee-related operations.

### 2. Service Implementation

`EmployeeService` implements `IEmployeeService` and handles the CRUD business logic.

### 3. Dependency Injection

ASP.NET Core provides the required service dependency instead of creating the service manually inside the Controller.

### 4. Constructor Injection

`EmployeeController` receives `IEmployeeService` through its constructor.

### 5. Service Registration

The service is registered in `Program.cs` using:

```csharp
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
```

`AddScoped()` creates one service instance per HTTP request scope.

## Features

The API supports the following CRUD operations:

| HTTP Method | Endpoint | Description |
|---|---|---|
| GET | `/api/employee` | Retrieve all employees |
| GET | `/api/employee/{id}` | Retrieve an employee by ID |
| POST | `/api/employee` | Add a new employee |
| PUT | `/api/employee/{id}` | Update an existing employee |
| DELETE | `/api/employee/{id}` | Delete an employee |

## Getting Started

### 1. Navigate to the project directory

```bash
cd EmployeeAPI
```

### 2. Run the application

```bash
dotnet run
```

The API will be available at the local URL shown in the terminal.

Example:

```text
http://localhost:5247
```

### 3. Test the API

Use Postman to send HTTP requests to the API.

#### GET - Retrieve all employees

```http
GET /api/employee
```

#### GET - Retrieve an employee by ID

```http
GET /api/employee/1
```

#### POST - Add a new employee

```http
POST /api/employee
Content-Type: application/json
```

Request Body:

```json
{
    "name": "David",
    "position": "Backend Developer"
}
```

#### PUT - Update an employee

```http
PUT /api/employee/3
Content-Type: application/json
```

Request Body:

```json
{
    "id": 3,
    "name": "David",
    "position": "Senior Backend Developer"
}
```

#### DELETE - Delete an employee

```http
DELETE /api/employee/3
```

## HTTP Status Codes

| Status Code | Description |
|---|---|
| 200 OK | Request completed successfully |
| 201 Created | A new employee was created |
| 204 No Content | Employee deleted successfully |
| 404 Not Found | Employee does not exist |

## Data Storage

This project uses a static in-memory `List<Employee>` inside `EmployeeService` to store employee records.

**Note:** Data is temporary and will be reset when the application restarts. No database is used in this lab.

## Learning Outcomes

After completing this lab, I learned how to:

- Understand the Interface and Implementation concepts.
- Apply the Service Layer pattern to separate business logic from Controllers.
- Implement Dependency Injection in ASP.NET Core.
- Use Constructor Injection to provide service dependencies.
- Register services using `AddScoped()`.
- Understand the differences between Transient, Scoped, and Singleton lifetimes.
- Refactor an existing CRUD API without changing its external API behavior.
- Build and test the application using Postman.

## Testing Results

All CRUD operations were tested successfully using Postman, including successful requests and not-found scenarios.

The project was successfully built using `dotnet build`.

**Status: Completed**

## Development History

- Lab 01: Created the first ASP.NET Core Web API.
- Lab 02: Implemented Employee Management CRUD operations using Controllers.
- Lab 03: Refactored the application using Dependency Injection and the Service Layer pattern.