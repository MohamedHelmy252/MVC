using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
    public class Department : ModelBase
    {
        public string Code { get; set; } = null!;//Not Allow Null
        public string? Description { get; set; }
        public DateOnly CreatedDate { get; set; }  

    }
}
