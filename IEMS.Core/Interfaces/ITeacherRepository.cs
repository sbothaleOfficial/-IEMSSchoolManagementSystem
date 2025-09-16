using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface ITeacherRepository : IRepository<Teacher>
{
    Task<Teacher?> GetTeacherByEmployeeIdAsync(string employeeId);
    Task<IEnumerable<Teacher>> GetTeachersBySubjectAsync(string subject);
}