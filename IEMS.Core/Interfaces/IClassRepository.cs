using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IClassRepository : IRepository<Class>
{
    Task<IEnumerable<Class>> GetClassesByTeacherIdAsync(int teacherId);
    Task<Class?> GetClassWithStudentsAsync(int classId);
}