using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Employee;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Presistance.Repositories.Employee;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public int CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            var employee = new IKEA.DAL.Models.Employees.Employee()
            {
              
                Name = createEmployeeDTO.Name,  
                Age = createEmployeeDTO.Age,
                Address = createEmployeeDTO.Address,    
                IsActive = createEmployeeDTO.IsActive,  
                Salary = createEmployeeDTO.Salary,  
                Email = createEmployeeDTO.Email,    
                EmployeeType = createEmployeeDTO.EmployeeType,  
                Gender = createEmployeeDTO.Gender,
            
                DepartmentId = createEmployeeDTO.DepartmentId,
                HiringDate = DateTime.Now,
                PhoneNumber = createEmployeeDTO.PhoneNumber,
                LastModifiedBy=1,
                LastModifiedOn=DateTime.Now,
                CreatedBy=1,
                CreatedOn=DateTime.Now,

                
            };
            return _employeeRepository.Add(employee);
        }
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeRepository.GetAll()
                .Select(item => new EmployeeDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Address = item.Address,
                    IsActive = item.IsActive,
                    Salary = item.Salary,
                    Email = item.Email,
                    EmployeeType = item.EmployeeType,
                    Gender = item.Gender,
                    DepartmentId = item.DepartmentId,
                    HiringDate = DateTime.Now,
                    PhoneNumber = item.PhoneNumber,
                    LastModifiedBy = 1,
                    LastModifiedOn = DateTime.Now,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                    Department = item.Department.Name
                });
        }

        public EmployeeDTO GetById(int id)
        {
        var employee=_employeeRepository.GetById(id);

            if (employee is not null)
            {
                return new EmployeeDTO
                {
                    Id=employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    EmployeeType = employee.EmployeeType,
                    Gender = employee.Gender,
                    DepartmentId = employee.DepartmentId,
                    HiringDate = DateTime.Now,
                    PhoneNumber = employee.PhoneNumber,
                    LastModifiedBy = 1,
                    LastModifiedOn = DateTime.Now,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now,
                };
            
            }
            return null;
        }

        public int UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {//mapping
                Id= employeeDTO.Id,
                Name = employeeDTO.Name,
                Age = employeeDTO.Age,
                Address = employeeDTO.Address,
                IsActive = employeeDTO.IsActive,
                Salary = employeeDTO.Salary,
                Email = employeeDTO.Email,
                EmployeeType = employeeDTO.EmployeeType,
                Gender = employeeDTO.Gender,
                DepartmentId= employeeDTO.DepartmentId, 
                HiringDate = DateTime.Now,
                PhoneNumber = employeeDTO.PhoneNumber,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
            };
            return _employeeRepository.Update(employee);
        }
        public bool DeleteEmployee(int id)
        {
          var employee=_employeeRepository.GetById(id);
            if (employee != null)
            {
                return _employeeRepository.Delete(employee)>0;
            }
            return false;
        }

   
    }
}
