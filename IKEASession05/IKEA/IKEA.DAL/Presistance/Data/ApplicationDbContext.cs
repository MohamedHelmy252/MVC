using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IKEA.DAL.Models.Employees;
namespace IKEA.DAL.Presistance.Data
{
    public class ApplicationDbContext : DbContext 
    {

        #region  OnConfiguring




        //   الافضل هو استخدام ال [ Dependency Injection ]
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-H5JGK8F;Database=IKEA;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        //================================================================================
        //[ Dependency Injection ]

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Option):base(Option)
        {
        }
        //Go To Program.cs   And AppSetting 



        #endregion
        #region OnModelCreating
        //using System.Reflection;    Must Add First
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion
        #region DbSet
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion

    }
}
