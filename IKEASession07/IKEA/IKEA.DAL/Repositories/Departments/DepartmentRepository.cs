using IKEA.DAL.Data;
using IKEA.DAL.Entities.Departments;
using IKEA.DAL.Repositories.Generic;

namespace IKEA.DAL.Repositories.Departments;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext dbContext)
        : base(dbContext)
    {

    }
}
