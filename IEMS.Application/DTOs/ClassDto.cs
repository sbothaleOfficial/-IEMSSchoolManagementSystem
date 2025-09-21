namespace IEMS.Application.DTOs;

public class ClassDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = string.Empty;
    public int StudentCount { get; set; }
    public string DisplayName => string.IsNullOrWhiteSpace(Section) ? Name : $"{Name} - {Section}";
    public string FullDescription => string.IsNullOrWhiteSpace(Section) ? $"{Name} (Class Teacher: {TeacherName})" : $"{Name} - {Section} (Class Teacher: {TeacherName})";
}