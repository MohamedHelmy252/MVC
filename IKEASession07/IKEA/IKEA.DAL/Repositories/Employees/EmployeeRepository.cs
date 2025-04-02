using IKEA.DAL.Data;
using IKEA.DAL.Entities.Employees;
using IKEA.DAL.Repositories.Generic;

namespace IKEA.DAL.Repositories.Employees;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext dbContext)
        : base(dbContext)
    {

    }
}
