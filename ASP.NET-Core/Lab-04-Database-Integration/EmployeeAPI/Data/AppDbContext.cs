using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Engineering", Location = "Building A" },
            new Department { Id = 2, Name = "Human Resources", Location = "Building B" },
            new Department { Id = 3, Name = "Marketing", Location = "Building C" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "John", Position = "Developer" },
            new Employee { Id = 2, Name = "Sarah", Position = "Designer" }
        );
    }
}