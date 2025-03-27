using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Common;
using IKEA.DAL.Models.Departments;

namespace IKEA.DAL.Models.Employees
{
    public class Employee : ModelBase
    {

        public int? Age { get; set; }
        public string? Address { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }


        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        bool IsDeleted { get; set; }



        #region Relation For Department
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        #endregion



    }
}
