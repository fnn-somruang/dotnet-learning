# Lab 01: My First ASP.NET Core Web API

## Objective
Learn how to create and run an ASP.NET Core Web API using .NET 10.

## Technologies
- C#
- ASP.NET Core 10
- Visual Studio Code
- Postman

## Topics Covered
- ASP.NET Core Project Setup
- Controllers and Routing
- HTTP GET Method
- JSON Response
- Running a Local Web Server
- API Testing with Postman

## Implemented Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/hello` | Returns a greeting message |
| GET | `/api/student` | Returns student information |

## Expected Response

### GET /api/hello

```json
{
  "message": "Hello, World!"
}
```

### GET /api/student

```json
{
  "name": "Nawapon Somruang",
  "major": "Software Engineering",
  "university": "Chiang Mai University"
}
```

## Lab Status
Completed

## Key Learnings
- Creating ASP.NET Core Web API projects.
- Implementing API Controllers.
- Configuring API Routes.
- Returning JSON responses.
- Testing endpoints using Postman.
