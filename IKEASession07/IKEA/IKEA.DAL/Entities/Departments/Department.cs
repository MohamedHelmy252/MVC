using IKEA.DAL.Entities.Employees;

namespace IKEA.DAL.Entities.Departments;

public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly CreationDate { get; set; }

    public ICollection<Employee> Employees { get; set; } =
        new HashSet<Employee>();

}
