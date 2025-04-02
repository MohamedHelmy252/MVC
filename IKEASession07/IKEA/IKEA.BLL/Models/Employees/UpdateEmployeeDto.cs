using IKEA.DAL.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace IKEA.BLL.Models.Employees;

public class UpdateEmployeeDto
{
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "Name Must 50 Chars")]
    [MinLength(5, ErrorMessage = "Name Must be more 5 Chars")]
    public string Name { get; set; } = null!;

    [Range(22, 30)]
    public int? Age { get; set; }
    public string? Address { get; set; }
    public decimal Salary { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Display(Name = "Phone Number")]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Hiring Date")]
    public DateTime HiringDate { get; set; }
    public Gender Gender { get; set; }
    public EmployeeType EmployeeType { get; set; }
}
