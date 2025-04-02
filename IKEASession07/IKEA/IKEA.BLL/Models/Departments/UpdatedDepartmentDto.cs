using System.ComponentModel.DataAnnotations;

namespace IKEA.BLL.Models.Departments;

public class UpdatedDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Code Is Required")]
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly CreationDate { get; set; }
}
