using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Department
{
    public class DepartmentToReturnDTO
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } = null!;//Not Allow Null
        public string? Description { get; set; }
        //public int CreatedBy { get; set; }
        public int Id { get; internal set; }
        public object Descriptiosn { get; internal set; }
        public DateTime CreatedOn { get; set; }
        //public int LastModifiedBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }
        //bool IsDeleted { get; set; }
        //public DateOnly CreatedDate { get; set; }
    }
}
