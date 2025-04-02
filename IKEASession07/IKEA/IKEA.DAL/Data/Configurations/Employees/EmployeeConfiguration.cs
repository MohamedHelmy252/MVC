using IKEA.DAL.Common.Enums;
using IKEA.DAL.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Data.Configurations.Employees;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .Property(e => e.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(e => e.Address)
            .HasColumnType("varchar(100)");

        builder
            .Property(e => e.Salary)
            .HasColumnType("decimal(8,2)");

        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .Property(e => e.Gender)
            .HasConversion(
            (gender) => gender.ToString(),
            (gender) => (Gender)Enum.Parse(typeof(Gender), gender));

        builder
            .Property(e => e.EmployeeType)
            .HasConversion(
            (type) => type.ToString(),
            (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));
    }
}
