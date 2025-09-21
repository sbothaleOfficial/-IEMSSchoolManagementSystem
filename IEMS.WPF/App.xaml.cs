using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IEMS.Infrastructure.Data;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Repositories;
using IEMS.Application.Services;
using IEMS.Core.Services;

namespace IEMS.WPF;

public partial class App : System.Windows.Application
{
    private IHost? _host;

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

                    // Domain Services (will be used by FeePaymentService)
                    services.AddScoped<FeeCalculationService>();
                    services.AddScoped<AmountToWordsService>();
                    services.AddScoped<StudentPromotionService>();

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
                    services.AddScoped<BulkPromotionService>();

                    services.AddSingleton<MainWindow>();
                })
                .Build();

            await _host.StartAsync();

            using (var scope = _host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            this.MainWindow = mainWindow;
            mainWindow.Show();

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