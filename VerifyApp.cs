using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Data.Sqlite;

class VerifyApp
{
    static void Main()
    {
        Console.WriteLine("=== IEMS Application Verification ===\n");

        // Check if executable exists
        var exePath = Path.Combine("publish", "IEMS.WPF.exe");
        Console.WriteLine($"1. Checking executable: {exePath}");
        if (File.Exists(exePath))
        {
            Console.WriteLine("   ✓ Executable found!");
            var fileInfo = new FileInfo(exePath);
            Console.WriteLine($"   - Size: {fileInfo.Length / 1024} KB");
            Console.WriteLine($"   - Created: {fileInfo.CreationTime}");
        }
        else
        {
            Console.WriteLine("   ✗ Executable not found!");
        }

        // Check database
        Console.WriteLine("\n2. Checking database:");
        var dbPaths = new[] { "IEMS.WPF/school.db", "school.db" };
        foreach (var dbPath in dbPaths)
        {
            if (File.Exists(dbPath))
            {
                Console.WriteLine($"   ✓ Database found at: {dbPath}");

                try
                {
                    using var connection = new SqliteConnection($"Data Source={dbPath}");
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM Students";
                    var studentCount = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "SELECT COUNT(*) FROM Teachers";
                    var teacherCount = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "SELECT COUNT(*) FROM Classes";
                    var classCount = Convert.ToInt32(cmd.ExecuteScalar());

                    Console.WriteLine($"   - Students: {studentCount}");
                    Console.WriteLine($"   - Teachers: {teacherCount}");
                    Console.WriteLine($"   - Classes: {classCount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"   Error reading database: {ex.Message}");
                }
            }
        }

        // Try to launch application
        Console.WriteLine("\n3. Attempting to launch application:");
        if (File.Exists(exePath))
        {
            try
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = Path.GetFullPath(exePath),
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetFullPath("publish")
                });

                Console.WriteLine("   ✓ Application launched!");
                Console.WriteLine("   - Look for the IEMS window on your desktop");
                Console.WriteLine("   - The window title is: 'IEMS - School Management System'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   ✗ Failed to launch: {ex.Message}");
            }
        }

        Console.WriteLine("\n=== Verification Complete ===");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}