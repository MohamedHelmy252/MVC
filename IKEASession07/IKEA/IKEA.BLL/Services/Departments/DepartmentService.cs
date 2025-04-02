using IKEA.BLL.Models.Departments;
using IKEA.DAL.Entities.Departments;
using IKEA.DAL.Repositories.Departments;
using Microsoft.EntityFrameworkCore;

namespace IKEA.BLL.Services.Departments;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IEnumerable<DepartmentDto> GetAllDepartments()
    {
        var departments = _departmentRepository.GetAllAsQueryable()
            .Select(department => new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
            }).AsNoTracking().ToList();

        return departments;
    }

    public DepartmentDetailsDto? GetDepartmentById(int id)
    {
        var department = _departmentRepository.GetById(id);
        if (department is not null)
        {
            return new DepartmentDetailsDto
            {
                Id = department!.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = department.CreatedBy,
                CreatedAt = department.CreatedAt,
                LastModificationBy = department.LastModificationBy,
                LastModificationAt = department.LastModificationAt
            };
        }
        return null;
    }

    public int UpdateDepartment(UpdatedDepartmentDto depatmentDto)
    {
        var existingDepartment = _departmentRepository
            .GetById(depatmentDto.Id);
        if (existingDepartment == null)
        {
            throw new Exception("Department not found");
        }

        existingDepartment.Code = depatmentDto.Code;
        existingDepartment.Name = depatmentDto.Name;
        existingDepartment.CreationDate = depatmentDto.CreationDate;
        existingDepartment.Description = depatmentDto.Description;
        existingDepartment.LastModificationBy = 1;
        existingDepartment.LastModificationAt = DateTime.UtcNow;

        return _departmentRepository.Update(existingDepartment);
    }

    public int CreateDepartment(CreatedDepartmentDto createdDepatmentDto)
    {
        var department = new Department
        {
            Code = createdDepatmentDto.Code,
            Name = createdDepatmentDto.Name,
            Description = createdDepatmentDto.Description,
            CreationDate = createdDepatmentDto.CreationDate,
            CreatedBy = 1,
            LastModificationBy = 1,
            LastModificationAt = DateTime.UtcNow
        };
        return _departmentRepository.Add(department);
    }

    public bool DeleteDepartment(int id)
    {
        var department = _departmentRepository.GetById(id);

        if (department is not null)
            return _departmentRepository.Delete(department!) > 0;

        return false;
    }
}
