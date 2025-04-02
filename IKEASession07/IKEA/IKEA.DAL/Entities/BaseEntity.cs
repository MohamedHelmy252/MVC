namespace IKEA.DAL.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int LastModificationBy { get; set; }
    public DateTime LastModificationAt { get; set; }
    public bool IsDeleted { get; set; }
}
