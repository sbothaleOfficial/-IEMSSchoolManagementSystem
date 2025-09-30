using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Core.Services;

namespace IEMS.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHashingService _passwordHashingService;

        public UserService(IUserRepository userRepository, PasswordHashingService passwordHashingService)
        {
            _userRepository = userRepository;
            _passwordHashingService = passwordHashingService;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null || !user.IsActive)
            {
                return null;
            }

            // Verify password
            if (!_passwordHashingService.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            // Update last login
            user.LastLogin = DateTime.Now;
            await _userRepository.UpdateAsync(user);

            return user;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _userRepository.GetActiveUsersAsync();
        }

        public async Task<User> CreateUserAsync(string username, string password, string fullName, string role, string email, string createdBy)
        {
            // Check if username already exists
            if (await _userRepository.UsernameExistsAsync(username))
            {
                throw new InvalidOperationException($"Username '{username}' already exists.");
            }

            var user = new User
            {
                Username = username,
                PasswordHash = _passwordHashingService.HashPassword(password),
                FullName = fullName,
                Role = role,
                Email = email,
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedBy = createdBy,
                MustChangePassword = false
            };

            return await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user, string modifiedBy)
        {
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = modifiedBy;
            await _userRepository.UpdateAsync(user);
        }

        public async Task ResetPasswordAsync(int userId, string newPassword, string modifiedBy)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.PasswordHash = _passwordHashingService.HashPassword(newPassword);
            user.MustChangePassword = true;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = modifiedBy;

            await _userRepository.UpdateAsync(user);
        }

        public async Task ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Verify current password
            if (!_passwordHashingService.VerifyPassword(currentPassword, user.PasswordHash))
            {
                throw new InvalidOperationException("Current password is incorrect.");
            }

            user.PasswordHash = _passwordHashingService.HashPassword(newPassword);
            user.MustChangePassword = false;
            user.ModifiedDate = DateTime.Now;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DisableUserAsync(int userId, string modifiedBy)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.IsActive = false;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = modifiedBy;

            await _userRepository.UpdateAsync(user);
        }

        public async Task EnableUserAsync(int userId, string modifiedBy)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            user.IsActive = true;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = modifiedBy;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> UsernameExistsAsync(string username, int? excludeUserId = null)
        {
            return await _userRepository.UsernameExistsAsync(username, excludeUserId);
        }

        public async Task<int> GetUserCountAsync()
        {
            return await _userRepository.GetUserCountAsync();
        }

        public async Task EnsureDefaultAdminExistsAsync()
        {
            // Check if any users exist
            var userCount = await GetUserCountAsync();

            if (userCount == 0)
            {
                // Create default admin account
                await CreateUserAsync(
                    username: "admin",
                    password: "admin123",
                    fullName: "System Administrator",
                    role: "Admin",
                    email: "admin@iemsschool.edu.in",
                    createdBy: "System"
                );
            }
        }
    }
}