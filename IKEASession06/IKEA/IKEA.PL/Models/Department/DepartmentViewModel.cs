namespace IKEA.PL.Models.Department
{
    public class DepartmentViewModel
    {
        public string Code { get; set; } = null!;//Not Allow Null
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
