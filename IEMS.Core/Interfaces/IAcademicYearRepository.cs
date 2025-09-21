using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IAcademicYearRepository : IRepository<AcademicYear>
{
    Task<AcademicYear?> GetCurrentAcademicYearAsync();
    Task<IEnumerable<AcademicYear>> GetRecentAcademicYearsAsync(int count = 5);
    Task SetCurrentAcademicYearAsync(int academicYearId);
}