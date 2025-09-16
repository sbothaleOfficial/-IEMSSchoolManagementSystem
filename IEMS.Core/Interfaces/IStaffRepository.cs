using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IStaffRepository : IRepository<Staff>
{
    Task<Staff?> GetStaffByEmployeeIdAsync(string employeeId);
    Task<IEnumerable<Staff>> GetStaffByPositionAsync(string position);
    Task<IEnumerable<string>> GetPositionsAsync();
}