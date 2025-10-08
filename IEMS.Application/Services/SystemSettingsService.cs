using Microsoft.EntityFrameworkCore;
using IEMS.Application.Interfaces;
using IEMS.Core.Entities;
using IEMS.Infrastructure.Data;
using System.ComponentModel;
using System.Globalization;

namespace IEMS.Application.Services
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly ApplicationDbContext _context;

        public SystemSettingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemSetting>> GetAllSettingsAsync()
        {
            return await _context.SystemSettings
                .OrderBy(s => s.Category)
                .ThenBy(s => s.Key)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemSetting>> GetSettingsByCategoryAsync(string category)
        {
            return await _context.SystemSettings
                .Where(s => s.Category == category)
                .OrderBy(s => s.Key)
                .ToListAsync();
        }

        public async Task<SystemSetting?> GetSettingAsync(string key)
        {
            return await _context.SystemSettings
                .FirstOrDefaultAsync(s => s.Key == key);
        }

        public async Task<string?> GetSettingValueAsync(string key)
        {
            var setting = await GetSettingAsync(key);
            return setting?.Value;
        }

        public async Task<T?> GetSettingValueAsync<T>(string key)
        {
            var value = await GetSettingValueAsync(key);
            if (string.IsNullOrEmpty(value))
                return default(T);

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    return (T?)converter.ConvertFromString(null, CultureInfo.InvariantCulture, value);
                }

                // Handle common types explicitly
                if (typeof(T) == typeof(bool))
                {
                    return (T)(object)bool.Parse(value);
                }
                if (typeof(T) == typeof(int))
                {
                    return (T)(object)int.Parse(value);
                }
                if (typeof(T) == typeof(decimal))
                {
                    return (T)(object)decimal.Parse(value, CultureInfo.InvariantCulture);
                }
                if (typeof(T) == typeof(DateTime))
                {
                    return (T)(object)DateTime.Parse(value, CultureInfo.InvariantCulture);
                }

                return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                // FIXED BUG #4: Log exception details to help diagnose type conversion and database issues
                System.Diagnostics.Debug.WriteLine($"Error converting setting '{key}' to type {typeof(T).Name}: {ex.Message}");
                return default(T);
            }
        }

        public async Task<bool> UpdateSettingAsync(string key, string value)
        {
            // FIXED BUG #13: Validate key parameter to prevent ArgumentException
            if (string.IsNullOrWhiteSpace(key))
                return false;

            var setting = await GetSettingAsync(key);
            if (setting == null || setting.IsReadOnly)
                return false;

            setting.Value = value;
            setting.ModifiedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating setting '{key}': {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateSettingsAsync(IEnumerable<SystemSetting> settings)
        {
            // FIXED BUG #1: Add transaction management to ensure data integrity
            // If any part of the update fails, all changes are rolled back
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Fetch all settings to update in one query to avoid N+1 problem
                var settingKeys = settings.Select(s => s.Key).ToList();
                var existingSettings = await _context.SystemSettings
                    .Where(s => settingKeys.Contains(s.Key))
                    .ToListAsync();

                // Create a dictionary for fast lookup
                var existingDict = existingSettings.ToDictionary(s => s.Key);

                foreach (var settingUpdate in settings)
                {
                    if (existingDict.TryGetValue(settingUpdate.Key, out var existing) && !existing.IsReadOnly)
                    {
                        existing.Value = settingUpdate.Value;
                        existing.ModifiedAt = DateTime.UtcNow;
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                System.Diagnostics.Debug.WriteLine($"Error updating settings: {ex.Message}\nStack Trace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> ResetSettingToDefaultAsync(string key)
        {
            var setting = await GetSettingAsync(key);
            if (setting == null || setting.IsReadOnly || string.IsNullOrEmpty(setting.DefaultValue))
                return false;

            setting.Value = setting.DefaultValue;
            setting.ModifiedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resetting setting '{key}' to default: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ResetCategoryToDefaultAsync(string category)
        {
            // FIXED BUG #12: Query database with filters instead of loading all and filtering in memory
            var resettableSettings = await _context.SystemSettings
                .Where(s => s.Category == category && !s.IsReadOnly && s.DefaultValue != null && s.DefaultValue != "")
                .ToListAsync();

            if (!resettableSettings.Any())
                return false;

            try
            {
                foreach (var setting in resettableSettings)
                {
                    setting.Value = setting.DefaultValue!;
                    setting.ModifiedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resetting category '{category}' to defaults: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ResetAllToDefaultAsync()
        {
            // FIXED BUG #12: Query database with filters instead of loading all and filtering in memory
            var resettableSettings = await _context.SystemSettings
                .Where(s => !s.IsReadOnly && s.DefaultValue != null && s.DefaultValue != "")
                .ToListAsync();

            if (!resettableSettings.Any())
                return false;

            try
            {
                foreach (var setting in resettableSettings)
                {
                    setting.Value = setting.DefaultValue!;
                    setting.ModifiedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resetting all settings to defaults: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            return await _context.SystemSettings
                .Select(s => s.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }
    }
}