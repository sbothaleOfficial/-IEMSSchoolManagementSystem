# IEMS - School Management System

A Windows desktop application for school management built with WPF and .NET 8.

## Features

- Student Management (CRUD operations)
- Class Management
- Teacher Management
- SQLite database for offline-first approach
- Clean Architecture design

## Prerequisites

- .NET 8.0 SDK
- Windows 10/11

## How to Run

### Method 1: Using Windows Command Prompt or PowerShell

1. Open Command Prompt or PowerShell (not Git Bash)
2. Navigate to the project directory:
   ```
   cd C:\Users\SP\Development\IEMSSchoolManagementSystem
   ```
3. Run the application:
   ```
   dotnet run --project IEMS.WPF
   ```

### Method 2: Using the Batch File

1. Double-click `RunApplication.bat` in Windows Explorer
2. The application will start automatically

### Method 3: Using Visual Studio

1. Open `IEMS.WindowsApp.sln` in Visual Studio
2. Set `IEMS.WPF` as the startup project
3. Press F5 to run

## Project Structure

- **IEMS.Core**: Domain entities and interfaces
- **IEMS.Application**: Business logic and services
- **IEMS.Infrastructure**: Data access layer with Entity Framework Core
- **IEMS.WPF**: Windows Presentation Foundation UI
- **IEMS.Shared**: Shared utilities and constants

## Database

The application uses SQLite database which is created automatically on first run. The database file `school.db` will be created in the `IEMS.WPF` folder with sample data.

## Known Issues

- The WPF application requires Windows Desktop Runtime and cannot be run from Git Bash/MINGW
- Use Windows Command Prompt, PowerShell, or Visual Studio to run the application

## Development

To build the solution:
```
dotnet build
```

To run tests:
```
dotnet test
```