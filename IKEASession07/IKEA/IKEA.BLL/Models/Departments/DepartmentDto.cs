namespace IKEA.BLL.Models.Departments;

public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateOnly CreationDate { get; set; }
}
