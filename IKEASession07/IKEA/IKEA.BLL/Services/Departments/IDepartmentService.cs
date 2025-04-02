using IKEA.BLL.Models.Departments;

namespace IKEA.BLL.Services.Departments;

public interface IDepartmentService
{
    IEnumerable<DepartmentDto> GetAllDepartments();
    DepartmentDetailsDto? GetDepartmentById(int id);
    int CreateDepartment(CreatedDepartmentDto createdDepatmentDto);
    int UpdateDepartment(UpdatedDepartmentDto depatmentDto);
    bool DeleteDepartment(int id);

}
