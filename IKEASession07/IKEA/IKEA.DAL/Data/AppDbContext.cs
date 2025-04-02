using IKEA.DAL.Entities.Departments;
using IKEA.DAL.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IKEA.DAL.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly
            .GetExecutingAssembly());
    }
}
