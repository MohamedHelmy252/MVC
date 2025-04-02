using IKEA.BLL.Models.Employees;
using IKEA.DAL.Entities.Employees;
using IKEA.DAL.Repositories.Employees;

namespace IKEA.BLL.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public int CreateEmployee(CreatedEmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Name = employeeDto.Name,
            Age = employeeDto.Age,
            Address = employeeDto.Address,
            IsActive = employeeDto.IsActive,
            Salary = employeeDto.Salary,
            Email = employeeDto.Email,
            PhoneNumber = employeeDto.PhoneNumber,
            HiringDate = employeeDto.HiringDate,
            Gender = employeeDto.Gender,
            EmployeeType = employeeDto.EmployeeType,
            CreatedBy = 1,
            LastModificationBy = 1,
            LastModificationAt = DateTime.UtcNow
        };

        return _employeeRepository.Add(employee);
    }

    public int UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Id = employeeDto.Id,
            Name = employeeDto.Name,
            Age = employeeDto.Age,
            Address = employeeDto.Address,
            IsActive = employeeDto.IsActive,
            Salary = employeeDto.Salary,
            Email = employeeDto.Email,
            PhoneNumber = employeeDto.PhoneNumber,
            HiringDate = employeeDto.HiringDate,
            Gender = employeeDto.Gender,
            EmployeeType = employeeDto.EmployeeType,
            CreatedBy = 1,
            LastModificationBy = 1,
            LastModificationAt = DateTime.UtcNow
        };

        return _employeeRepository.Update(employee);
    }

    public bool DeleteEmployee(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee is not null)
            return _employeeRepository.Delete(employee) > 0;

        return false;
    }

    public IEnumerable<EmployeeDto> GetAllEmployees()
    {
        return _employeeRepository.GetAllAsQueryable()
            .Where(e => !e.IsDeleted)
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Address = e.Address,
                IsActive = e.IsActive,
                Salary = e.Salary,
                Email = e.Email,
                Gender = e.Gender,
                EmployeeType = e.EmployeeType,
            });
    }

    public EmployeeDetailsDto? GetEmployeeById(int id)
    {
        var employee = _employeeRepository.GetById(id);
        if (employee is not null)
            return new EmployeeDetailsDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
            };

        return null;
    }
}
