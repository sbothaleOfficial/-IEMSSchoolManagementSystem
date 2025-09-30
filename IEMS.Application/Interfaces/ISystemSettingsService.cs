using IEMS.Core.Entities;

namespace IEMS.Application.Interfaces
{
    public interface ISystemSettingsService
    {
        Task<IEnumerable<SystemSetting>> GetAllSettingsAsync();
        Task<IEnumerable<SystemSetting>> GetSettingsByCategoryAsync(string category);
        Task<SystemSetting?> GetSettingAsync(string key);
        Task<string?> GetSettingValueAsync(string key);
        Task<T?> GetSettingValueAsync<T>(string key);
        Task<bool> UpdateSettingAsync(string key, string value);
        Task<bool> UpdateSettingsAsync(IEnumerable<SystemSetting> settings);
        Task<bool> ResetSettingToDefaultAsync(string key);
        Task<bool> ResetCategoryToDefaultAsync(string category);
        Task<bool> ResetAllToDefaultAsync();
        Task<IEnumerable<string>> GetCategoriesAsync();
    }
}