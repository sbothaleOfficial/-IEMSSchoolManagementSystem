using System.Collections.Generic;
using System.Threading.Tasks;
using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<bool> UsernameExistsAsync(string username, int? excludeUserId = null);
        Task<int> GetUserCountAsync();
    }
}