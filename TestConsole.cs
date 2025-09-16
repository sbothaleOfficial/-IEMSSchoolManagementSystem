using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IEMS.Infrastructure.Data;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Repositories;
using IEMS.Application.Services;

class TestConsole
{
    static async Task Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite("Data Source=IEMS.WPF/school.db"));

                services.AddScoped<IStudentRepository, StudentRepository>();
                services.AddScoped<IClassRepository, ClassRepository>();
                services.AddScoped<StudentService>();
            })
            .Build();

        await host.StartAsync();

        using (var scope = host.Services.CreateScope())
        {
            var studentService = scope.ServiceProvider.GetRequiredService<StudentService>();

            Console.WriteLine("=== IEMS School Management System - Test Console ===");
            Console.WriteLine("\nFetching all students from database...\n");

            var students = await studentService.GetAllStudentsAsync();

            Console.WriteLine($"Found {students.Count()} students:");
            Console.WriteLine("----------------------------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine($"Roll: {student.RollNumber} | Name: {student.FirstName} {student.LastName}");
                Console.WriteLine($"  Email: {student.Email}");
                Console.WriteLine($"  Class: {student.ClassName}");
                Console.WriteLine($"  DOB: {student.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine("----------------------------------------------------");
            }

            Console.WriteLine("\nDatabase connection and data retrieval successful!");
        }

        await host.StopAsync();
    }
}