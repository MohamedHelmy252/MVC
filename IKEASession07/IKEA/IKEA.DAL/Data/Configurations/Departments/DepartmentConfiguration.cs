using IKEA.DAL.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Data.Configurations.Departments;

class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .Property(d => d.Id)
            .UseIdentityColumn(10, 10);
        builder
            .Property(d => d.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();
        builder
            .Property(d => d.Code)
            .HasColumnType("varchar(50)")
            .IsRequired();
        builder
            .Property(d => d.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        builder
            .Property(d => d.LastModificationAt)
            .HasComputedColumnSql("GETDATE()");

        builder
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
