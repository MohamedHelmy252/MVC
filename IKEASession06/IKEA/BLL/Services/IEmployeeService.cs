using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Employee;
using IKEA.DAL.Models.Employees;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDTO> GetAllEmployees();
        public EmployeeDTO GetById(int id);
        public int CreateEmployee (CreateEmployeeDTO createEmployeeDTO);
        public int UpdateEmployee(EmployeeDTO employeeDTO);
        bool DeleteEmployee(int id);
    }
}
