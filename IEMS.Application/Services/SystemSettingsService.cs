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
            catch
            {
                return default(T);
            }
        }

        public async Task<bool> UpdateSettingAsync(string key, string value)
        {
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
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateSettingsAsync(IEnumerable<SystemSetting> settings)
        {
            try
            {
                foreach (var settingUpdate in settings)
                {
                    var existing = await GetSettingAsync(settingUpdate.Key);
                    if (existing != null && !existing.IsReadOnly)
                    {
                        existing.Value = settingUpdate.Value;
                        existing.ModifiedAt = DateTime.UtcNow;
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
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
            catch
            {
                return false;
            }
        }

        public async Task<bool> ResetCategoryToDefaultAsync(string category)
        {
            var settings = await GetSettingsByCategoryAsync(category);
            var resettableSettings = settings.Where(s => !s.IsReadOnly && !string.IsNullOrEmpty(s.DefaultValue));

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
            catch
            {
                return false;
            }
        }

        public async Task<bool> ResetAllToDefaultAsync()
        {
            var settings = await GetAllSettingsAsync();
            var resettableSettings = settings.Where(s => !s.IsReadOnly && !string.IsNullOrEmpty(s.DefaultValue));

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
            catch
            {
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