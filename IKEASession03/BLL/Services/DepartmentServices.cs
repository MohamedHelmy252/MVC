using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Department;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Repositories.Departments;

namespace BLL.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentToReturnDTO> GetDepartments()
        {
           var department = _departmentRepository.GetAll();
            foreach (var item in department)
            {
               yield return new DepartmentToReturnDTO
               {
                   Id = item.Id,
                   Name = item.Name,
                   Code = item.Code,
                   Description = item.Description,
                   CreatedOn = item.CreatedOn
               };
            }
        }
        public DepartmentToReturnDetails GetDepartmentById(int id)
        {
            var department=_departmentRepository.GetById(id);
            if (department is not null)
            {
               return new DepartmentToReturnDetails
               {
                   Id = department.Id,
                   Name = department.Name,
                   Code = department.Code,
                   Description = department.Description,
                   CreatedBy = 1,
                   CreatedOn = DateTime.Now,
                   LastModifiedBy = 1,
                   LastModifiedOn = DateTime.Now,
                   CreatedDate = DateTime.Now
               };
            }
            return null;

        }
        public int CreateDepartment(CreateDepartmentDTo createDepartment)
        {
           Department department = new Department
           {
               Name = createDepartment.Name,
               Code = createDepartment.Code,
               Description = createDepartment.Description,
               CreatedBy = 1,
               CreatedOn = DateTime.Now,
               LastModifiedBy = 1,
               LastModifiedOn =DateTime.Now,
               CreatedDate = DateTime.Now
           };
            
            return _departmentRepository.Add(department);   
        }

        public int UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO)
        {
            var UpdatedDepartment = new Department
            {
                Id = departmentUpdateDTO.Id,
                Name = departmentUpdateDTO.Name,
                Code = departmentUpdateDTO.Code,
                Description = departmentUpdateDTO.Description,
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            return _departmentRepository.Update(UpdatedDepartment); 
        }
        public bool DeleteDepartment(int id)
        {
           var department = _departmentRepository.GetById(id);
            if (department is not null)
            {
                return _departmentRepository.Delete(department)>0;
            }
            return false;   
        }

    }
}
