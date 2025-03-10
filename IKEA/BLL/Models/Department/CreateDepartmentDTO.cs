using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Department
{
    public class CreateDepartmentDTo
    {
        public string Name { get; set; }
        [Required(ErrorMessage ="Code Is Required!")]
        public string Code { get; set; } = null!;//Not Allow Null
        public string? Description { get; set; }
        [Display (Name="Date Of Creation")]
        public DateTime CreatedOn { get; set; }
    }
}
