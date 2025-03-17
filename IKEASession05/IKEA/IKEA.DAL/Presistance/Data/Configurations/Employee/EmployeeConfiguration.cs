using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Common;
namespace IKEA.DAL.Presistance.Data.Configurations.Employee
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Models.Employees.Employee>
    {
        public void Configure(EntityTypeBuilder<Models.Employees.Employee> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(e => e.Email).HasColumnType("varchar(100)");
            builder.Property(e=>e.Salary).HasColumnType("decimal(8,2)");
            builder.Property(e => e.HiringDate)
            .HasColumnType("datetime2")
             .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired(false);  


            //Conversion  With Gender
            builder.Property(e=>e.Gender).HasConversion(
                (gender)=>gender.ToString(),
                (gender)=>(Gender)Enum.Parse(typeof(Gender),gender)
                );
            //Conversion With EmployeeType  
            builder.Property(e => e.EmployeeType).HasConversion
                (
                (EmpType)=> EmpType.ToString(),
                (EmpType)=>(EmployeeType)Enum.Parse(typeof(EmployeeType), EmpType)
                );

        }
    }
}
