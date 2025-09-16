using IEMS.Core.Entities;
using IEMS.Core.Enums;

namespace IEMS.Core.Interfaces;

public interface IFeeStructureRepository
{
    Task<IEnumerable<FeeStructure>> GetAllAsync();
    Task<FeeStructure?> GetByIdAsync(int id);
    Task<IEnumerable<FeeStructure>> GetByClassIdAsync(int classId);
    Task<IEnumerable<FeeStructure>> GetByClassIdAndAcademicYearAsync(int classId, string academicYear);
    Task<FeeStructure?> GetByClassIdFeeTypeAndAcademicYearAsync(int classId, FeeType feeType, string academicYear);
    Task<IEnumerable<FeeStructure>> GetByAcademicYearAsync(string academicYear);
    Task<FeeStructure> AddAsync(FeeStructure feeStructure);
    Task UpdateAsync(FeeStructure feeStructure);
    Task DeleteAsync(int id);
}