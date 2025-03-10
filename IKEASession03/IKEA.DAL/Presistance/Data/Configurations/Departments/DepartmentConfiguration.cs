using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Presistance.Data.Configurations.Departments
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
          builder.Property(I=>I.Id).UseIdentityColumn(10,10);
          builder.Property(N=>N.Name).HasColumnType("varchar(50)").IsRequired();
          builder.Property(C => C.Code).HasColumnType("varchar(50)").IsRequired();
            //Defualt Date For Craete Date And Last Modified Date   
          builder.Property(C => C.CreatedOn).HasDefaultValueSql("GETDATE()");
          builder.Property(C => C.LastModifiedOn).HasComputedColumnSql("GETDATE()");  
        }
    }
}
