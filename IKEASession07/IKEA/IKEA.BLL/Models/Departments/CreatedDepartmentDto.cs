using System.ComponentModel.DataAnnotations;

namespace IKEA.BLL.Models.Departments;

public class CreatedDepartmentDto
{
    [Required(ErrorMessage = "Name Is Required !!")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Code Is Required !!")]
    public string Code { get; set; } = null!;
    public string? Description { get; set; }

    [Display(Name = "Date Of Creation")]
    public DateOnly CreationDate { get; set; }
}
