using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// builder.Services.AddSingleton<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IEmployeeService, DbEmployeeService>();
builder.Services.AddScoped<IDepartmentService, DbDepartmentService>();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITransientOperation, OperationService>();
builder.Services.AddScoped<IScopedOperation, OperationService>();
builder.Services.AddSingleton<ISingletonOperation, OperationService>();

builder.Services.AddTransient<SecondaryOperationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();