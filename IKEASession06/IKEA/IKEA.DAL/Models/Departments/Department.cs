using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Employees;

namespace IKEA.DAL.Models.Departments
{
    public class Department : ModelBase
    {
        public string Code { get; set; } = null!;//Not Allow Null
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

        #region Relation For Employee
        public ICollection<Employee>? Employees { get; set; } = new HashSet<Employee>();

        #endregion

    }
}
