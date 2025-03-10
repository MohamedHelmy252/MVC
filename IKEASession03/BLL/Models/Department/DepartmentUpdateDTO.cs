using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Department
{
    public class DepartmentUpdateDTO
    {

        public int Id { get; set; } //To Arive at Department 
        public string Name { get; set; }
        public string Code { get; set; } = null!;//Not Allow Null
        public string? Description { get; set; }
        public int CreatedOn { get; set; }
    }
}
