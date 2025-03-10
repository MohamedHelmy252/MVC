using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Department;

namespace BLL.Services
{
    public interface IDepartmentServices
    {
        //1-Get All Departments Based On DepartmentToReturnDTO  
        IEnumerable<DepartmentToReturnDTO> GetDepartments();
        //2-Get Department Based On DepartmentToReturnDetails
        DepartmentToReturnDetails GetDepartmentById(int id);
        //3-Create Department Based On CreateDepartmentDTO
        int CreateDepartment(CreateDepartmentDTo createDepartment);
        //4-Update Department Based On DepartmentUpdateDTO
        int UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO);
        //5-Delete Department Based On DepartmentToReturnDetails
        bool DeleteDepartment(int id);  

    }
}
