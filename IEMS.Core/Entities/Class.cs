namespace IEMS.Core.Entities;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual Teacher? Teacher { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}