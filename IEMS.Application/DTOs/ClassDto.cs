namespace IEMS.Application.DTOs;

public class ClassDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = string.Empty;
    public string TeacherEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public int StudentCount { get; set; }
    public string DisplayName => $"{Name} - {Section}";
    public string FullDescription => $"{Name} - {Section} ({TeacherName} - {Subject})";
}