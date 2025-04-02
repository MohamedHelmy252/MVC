namespace IKEA.BLL.Models.Departments;

public class DepartmentDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int LastModificationBy { get; set; }
    public DateTime LastModificationAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateOnly CreationDate { get; set; }
}
