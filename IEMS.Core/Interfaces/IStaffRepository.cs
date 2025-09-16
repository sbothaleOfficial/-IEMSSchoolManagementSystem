using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IStaffRepository : IRepository<Staff>
{
    Task<Staff?> GetStaffByEmployeeIdAsync(string employeeId);
    Task<IEnumerable<Staff>> GetStaffByDepartmentAsync(string department);
    Task<IEnumerable<Staff>> GetStaffByPositionAsync(string position);
    Task<IEnumerable<string>> GetDepartmentsAsync();
    Task<IEnumerable<string>> GetPositionsAsync();
    Task<int> GetActiveStaffCountAsync();
}