using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IStudentRepository : IRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
    Task<Student?> GetStudentByStudentNumberAsync(string studentNumber);
    Task<IEnumerable<Student>> GetStudentsWithClassDetailsAsync(int classId);
    Task UpdateMultipleStudentsAsync(IEnumerable<Student> students);
    Task<IEnumerable<Student>> GetStudentsWithPendingFeesAsync(int classId);
}