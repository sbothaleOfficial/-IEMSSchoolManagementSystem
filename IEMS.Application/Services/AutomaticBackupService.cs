using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IEMS.Application.Services
{
    public class AutomaticBackupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AutomaticBackupService> _logger;
        private readonly string _scheduleConfigPath;
        private Timer? _timer;

        public AutomaticBackupService(IServiceProvider serviceProvider, ILogger<AutomaticBackupService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            var backupRootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IEMS_Backups");
            _scheduleConfigPath = Path.Combine(backupRootPath, "backup_schedule.json");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Automatic backup service started");

            // Check for scheduled backups every hour
            _timer = new Timer(
                async _ => await CheckAndExecuteScheduledBackups(),
                null,
                TimeSpan.Zero, // Start immediately
                TimeSpan.FromHours(1) // Check every hour
            );

            // Keep the service running
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private async Task CheckAndExecuteScheduledBackups()
        {
            try
            {
                var schedule = await LoadScheduleAsync();
                if (schedule == null)
                {
                    _logger.LogDebug("No backup schedule found");
                    return;
                }

                var now = DateTime.Now;

                // Check daily backup
                if (schedule.EnableDaily)
                {
                    if (await ShouldExecuteDailyBackup(schedule, now))
                    {
                        await ExecuteBackupAsync(BackupType.Daily, "Scheduled daily backup");
                    }
                }

                // Check weekly backup
                if (schedule.EnableWeekly)
                {
                    if (await ShouldExecuteWeeklyBackup(schedule, now))
                    {
                        await ExecuteBackupAsync(BackupType.Weekly, "Scheduled weekly backup");
                    }
                }

                // Check monthly backup
                if (schedule.EnableMonthly)
                {
                    if (await ShouldExecuteMonthlyBackup(schedule, now))
                    {
                        await ExecuteBackupAsync(BackupType.Monthly, "Scheduled monthly backup");
                    }
                }

                // Check incremental backup
                if (schedule.EnableIncremental)
                {
                    if (await ShouldExecuteIncrementalBackup(schedule, now))
                    {
                        await ExecuteBackupAsync(BackupType.Incremental, "Scheduled incremental backup");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking scheduled backups");
            }
        }

        private async Task<BackupSchedule?> LoadScheduleAsync()
        {
            try
            {
                if (!File.Exists(_scheduleConfigPath))
                    return null;

                var json = await File.ReadAllTextAsync(_scheduleConfigPath);
                return JsonSerializer.Deserialize<BackupSchedule>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load backup schedule");
                return null;
            }
        }

        private async Task<bool> ShouldExecuteDailyBackup(BackupSchedule schedule, DateTime now)
        {
            var lastExecution = await GetLastBackupTimeAsync(BackupType.Daily);

            // Convert scheduled time to today's datetime
            var scheduledTime = now.Date.Add(schedule.DailyTime);

            // If scheduled time has passed today and we haven't executed today
            if (now >= scheduledTime && (lastExecution == null || lastExecution.Value.Date < now.Date))
            {
                return true;
            }

            return false;
        }

        private async Task<bool> ShouldExecuteWeeklyBackup(BackupSchedule schedule, DateTime now)
        {
            var lastExecution = await GetLastBackupTimeAsync(BackupType.Weekly);

            // Check if today is the scheduled day and we haven't executed this week
            if (now.DayOfWeek == schedule.WeeklyDay)
            {
                if (lastExecution == null || (now - lastExecution.Value).TotalDays >= 7)
                {
                    return true;
                }
            }

            return false;
        }

        private async Task<bool> ShouldExecuteMonthlyBackup(BackupSchedule schedule, DateTime now)
        {
            var lastExecution = await GetLastBackupTimeAsync(BackupType.Monthly);

            // Calculate target day with fallback for shorter months
            int targetDay;
            if (schedule.MonthlyDay == -1) // Last day of month
            {
                targetDay = DateTime.DaysInMonth(now.Year, now.Month);
            }
            else
            {
                // If scheduled day doesn't exist in this month, use last day
                var daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                targetDay = Math.Min(schedule.MonthlyDay, daysInMonth);
            }

            // Check if we're on or past the target day AND haven't run this month
            var passedTargetDay = now.Day >= targetDay;
            var notRunThisMonth = lastExecution == null ||
                                 lastExecution.Value.Month != now.Month ||
                                 lastExecution.Value.Year != now.Year;

            return passedTargetDay && notRunThisMonth;
        }

        private async Task<bool> ShouldExecuteIncrementalBackup(BackupSchedule schedule, DateTime now)
        {
            var lastExecution = await GetLastBackupTimeAsync(BackupType.Incremental);

            if (lastExecution == null || (now - lastExecution.Value).TotalHours >= schedule.IncrementalIntervalHours)
            {
                return true;
            }

            return false;
        }

        private async Task<DateTime?> GetLastBackupTimeAsync(BackupType type)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var backupService = scope.ServiceProvider.GetService<IBackupService>();
                if (backupService != null)
                {
                    var history = await backupService.GetBackupHistoryAsync();
                    var lastBackup = history.Where(b => b.Type == type).OrderByDescending(b => b.Timestamp).FirstOrDefault();
                    return lastBackup?.Timestamp;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get last backup time for type {BackupType}", type);
                return null;
            }
        }

        private async Task ExecuteBackupAsync(BackupType type, string reason)
        {
            try
            {
                _logger.LogInformation("Executing {BackupType} backup: {Reason}", type, reason);

                using var scope = _serviceProvider.CreateScope();
                var backupService = scope.ServiceProvider.GetService<IBackupService>();
                if (backupService != null)
                {
                    var result = await backupService.CreateBackupAsync(type);
                    if (result.Success)
                    {
                        _logger.LogInformation("Backup completed successfully: {BackupPath}", result.BackupPath);
                    }
                    else
                    {
                        _logger.LogError("Backup failed: {ErrorMessage}", result.Message);
                    }
                }
                else
                {
                    _logger.LogError("BackupService not available in dependency injection container");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing {BackupType} backup", type);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Automatic backup service stopping");
            _timer?.Dispose();
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}