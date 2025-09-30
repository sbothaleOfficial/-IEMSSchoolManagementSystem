using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IEMS.Infrastructure.Data;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Repositories;
using IEMS.Application.Services;
using IEMS.Application.Interfaces;
using IEMS.Core.Services;
using IEMS.Core.Configuration;

namespace IEMS.WPF;

public partial class App : System.Windows.Application
{
    private IHost? _host;
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override async void OnStartup(StartupEventArgs e)
    {
        try
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlite("Data Source=school.db"));

                    services.AddScoped<IStudentRepository, StudentRepository>();
                    services.AddScoped<IClassRepository, ClassRepository>();
                    services.AddScoped<ITeacherRepository, TeacherRepository>();
                    services.AddScoped<IStaffRepository, StaffRepository>();
                    services.AddScoped<IFeePaymentRepository, FeePaymentRepository>();
                    services.AddScoped<IFeeStructureRepository, FeeStructureRepository>();
                    services.AddScoped<IVehicleRepository, VehicleRepository>();
                    services.AddScoped<ITransportExpenseRepository, TransportExpenseRepository>();
                    services.AddScoped<IElectricityBillRepository, ElectricityBillRepository>();
                    services.AddScoped<IOtherExpenseRepository, OtherExpenseRepository>();
                    services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
                    services.AddScoped<IUserRepository, UserRepository>();

                    // Configuration
                    var bulkPromotionConfig = new BulkPromotionConfiguration
                    {
                        EligibilityRules = new EligibilityRulesConfiguration
                        {
                            MaxPendingFees = 0m,  // Set to 0 since we don't allow any pending fees
                            MinAttendancePercentage = 75,
                            RequireTeacherApproval = false,
                            AllowPromotionWithPendingFees = false  // No pending fees allowed
                        },
                        ClassProgression = new ClassProgressionConfiguration
                        {
                            AllowSameGradePromotion = true,
                            AllowSkipGrade = false,
                            StrictProgressionOnly = true
                        }
                    };
                    services.AddSingleton(bulkPromotionConfig);

                    // Domain Services (will be used by FeePaymentService)
                    services.AddScoped<FeeCalculationService>();
                    services.AddScoped<AmountToWordsService>();
                    services.AddScoped<StudentPromotionService>();
                    services.AddScoped<StudentEligibilityValidator>();
                    services.AddScoped<ClassProgressionValidator>();
                    services.AddScoped<PasswordHashingService>();

                    // Application Services
                    services.AddScoped<StudentService>();
                    services.AddScoped<TeacherService>();
                    services.AddScoped<ClassService>();
                    services.AddScoped<StaffService>();
                    services.AddScoped<FeePaymentService>();
                    services.AddScoped<FeeStructureService>();
                    services.AddScoped<VehicleService>();
                    services.AddScoped<TransportExpenseService>();
                    services.AddScoped<ElectricityBillService>();
                    services.AddScoped<OtherExpenseService>();
                    services.AddScoped<AcademicYearService>();
                    services.AddScoped<BulkPromotionService>();
                    services.AddScoped<IBackupService, BackupService>();
                    services.AddScoped<ISystemSettingsService, SystemSettingsService>();
                    services.AddScoped<UserService>();
                    services.AddHostedService<AutomaticBackupService>();

                    services.AddTransient<MainWindow>();
                    services.AddTransient<FeeStructureManagementWindow>();
                    services.AddTransient<AddEditFeeStructureWindow>();
                })
                .Build();

            await _host.StartAsync();

            ServiceProvider = _host.Services;

            using (var scope = _host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Ensure default admin user exists
                var userService = scope.ServiceProvider.GetRequiredService<UserService>();
                await userService.EnsureDefaultAdminExistsAsync();
            }

            // Show login window first
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            base.OnStartup(e);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Application startup failed: {ex.Message}\n\nDetails: {ex.InnerException?.Message ?? ex.StackTrace}",
                           "Startup Error", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Shutdown(1);
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host?.Dispose();
        base.OnExit(e);
    }
}