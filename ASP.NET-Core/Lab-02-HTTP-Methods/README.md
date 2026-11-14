# Lab 02: HTTP Methods & Routing

## Overview

This lab focuses on building a simple Employee Management REST API using ASP.NET Core Web API with Controllers.

The purpose is to understand HTTP methods, routing, CRUD operations, and HTTP status codes. Employee data is stored in an in-memory `List<Employee>` without using a database.

## Technologies

- C#
- ASP.NET Core Web API
- .NET 10
- REST API
- Postman
- Visual Studio / Visual Studio Code

## Project Structure

```text
Lab-02-HTTP-Methods/
├── README.md
└── EmployeeAPI/
    ├── Controllers/
    │   └── EmployeeController.cs
    ├── Models/
    │   └── Employee.cs
    ├── Program.cs
    └── EmployeeAPI.csproj
```

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

You can use Postman to send HTTP requests to the API.

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

This project uses an in-memory `List<Employee>` to store employee records.

**Note:** Data is temporary and will be reset when the application restarts. No database is used in this lab.

## Learning Outcomes

After completing this lab, I learned how to:

- Create REST API endpoints using ASP.NET Core Controllers.
- Implement CRUD operations with GET, POST, PUT, and DELETE.
- Configure API routing and route parameters.
- Receive and return JSON data.
- Handle missing resources using HTTP 404 responses.
- Test API endpoints using Postman.
- Understand common HTTP status codes.

## Testing Results

All CRUD operations were tested successfully using Postman, including successful requests and the not-found scenarios.

**Status: Completed**