# IEMS School Management System

> A comprehensive Windows desktop application for managing school operations, built with .NET 8 and WPF.

[![.NET Version](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Platform](https://img.shields.io/badge/Platform-Windows-blue)](https://www.microsoft.com/windows)
[![License](https://img.shields.io/badge/License-MIT-green)]()

## Overview

IEMS (Inspire English Medium School) Management System is a feature-rich desktop application designed to streamline school administration. Built with Clean Architecture principles, it offers offline-first capabilities using SQLite for data persistence.

## Features

### Core Modules

- **Student Management**
  - Complete CRUD operations
  - Bulk student promotion
  - Aadhaar number integration
  - Excel export functionality
  - Search and filter capabilities

- **Teacher Management**
  - Teacher profiles with contact details
  - Subject assignment tracking
  - Class association management
  - Employee ID validation

- **Class Management**
  - Class creation and organization
  - Student-class associations
  - Teacher assignments
  - Section management

- **Staff Management**
  - Staff profiles and positions
  - Salary tracking
  - Department organization

### Financial Management

- **Fee Payment System**
  - Multiple payment methods (Cash, Online, Cheque, DD)
  - Fee structure per class and type
  - Receipt generation and printing
  - Payment history tracking
  - Late fee calculations
  - Discount management
  - Academic year management

- **Finance Management**
  - Electricity bill tracking
  - Other expense management
  - Financial analytics and reporting

- **Transport Management**
  - Vehicle information management
  - Fuel tracking
  - Transport expense monitoring

### Administrative Features

- **User Management**
  - Role-based access control
  - User CRUD operations
  - Password reset functionality
  - PBKDF2 password hashing

- **Backup & Restore**
  - Manual backup creation
  - Scheduled automatic backups
  - Database integrity checks
  - Restore from backup with verification

- **System Settings**
  - Configurable school information
  - Backup schedule configuration
  - Application preferences

### Document Generation

- **Leaving Certificate**
  - Student details auto-population
  - Customizable certificate templates
  - XPS/PDF export options
  - Print functionality

- **Bonafide Certificate**
  - Student verification documents
  - Configurable templates
  - Export and print capabilities

## Technology Stack

- **Framework**: .NET 8.0
- **UI**: Windows Presentation Foundation (WPF)
- **Database**: SQLite 3
- **ORM**: Entity Framework Core 8.0
- **Architecture**: Clean Architecture
- **Authentication**: Custom PBKDF2-based system

## System Requirements

### Minimum Requirements
- **OS**: Windows 10 (64-bit) or Windows 11
- **Processor**: Intel Core i3 or equivalent
- **RAM**: 4 GB
- **Storage**: 500 MB free space
- **Display**: 1280x720 resolution

### Recommended
- **OS**: Windows 11
- **Processor**: Intel Core i5 or higher
- **RAM**: 8 GB or more
- **Storage**: 1 GB free space
- **Display**: 1920x1080 resolution or higher

## Installation & Setup

### For End Users

1. **Download** the latest release package from the releases section
2. **Extract** `IEMS_Release_Package` to your desired location
3. **Run** `IEMS.WPF.exe`
4. **Login** with default credentials:
   - Username: `admin`
   - Password: `Admin@123`
5. **⚠️ IMPORTANT**: Change the default password immediately after first login

For detailed installation instructions, see [INSTALLATION_INSTRUCTIONS.txt](IEMS_Release_Package/INSTALLATION_INSTRUCTIONS.txt)

### For Developers

#### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows 10/11
- Visual Studio 2022 or VS Code (optional)

#### Setup Steps

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd IEMSSchoolManagementSystem
   ```

2. **Restore dependencies**
   ```bash
   # Downloads all NuGet packages required by the solution
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   # Compiles the entire solution in Debug mode
   dotnet build

   # Or build in Release mode for better performance
   dotnet build -c Release
   ```

4. **Run the application**

   **Option A: Run from source (Development)**
   ```bash
   # Fastest for development - runs directly from source code
   dotnet run --project IEMS.WPF
   ```

   **Option B: Run compiled executable**
   ```bash
   # Run the Debug build executable
   ./IEMS.WPF/bin/Debug/net8.0-windows/IEMS.WPF.exe

   # Or run the Release build (better performance)
   ./IEMS.WPF/bin/Release/net8.0-windows/IEMS.WPF.exe
   ```

   **Option C: Use convenience scripts**
   ```bash
   # Quick development run (builds and runs without full publish)
   RunLatest.cmd

   # Publish optimized version to publish/ folder and run
   PublishAndRun.cmd
   ```

5. **Database initialization**
   - The database (`school.db`) is created automatically on first run
   - Seed data includes sample students, teachers, and admin user
   - Database location: Root project directory

### Common Development Tasks

#### Clean build artifacts
```bash
# Removes all bin/ and obj/ folders
dotnet clean
```

#### Rebuild from scratch
```bash
# Clean + Build
dotnet clean && dotnet build
```

#### Run with hot reload (if available)
```bash
# Automatically rebuilds on code changes
dotnet watch run --project IEMS.WPF
```

## Project Structure

```
IEMSSchoolManagementSystem/
├── IEMS.Core/                 # Domain entities and interfaces
├── IEMS.Application/          # Business logic and services
├── IEMS.Infrastructure/       # Data access and EF Core
├── IEMS.WPF/                  # WPF UI layer
├── IEMS.Shared/               # Shared utilities
├── CreateInstaller.iss        # Inno Setup installer script
└── school.db                  # SQLite database (auto-generated)
```

### Architecture Layers

1. **Core Layer** (`IEMS.Core`)
   - Domain entities (Student, Teacher, Class, etc.)
   - Repository interfaces
   - Business domain logic

2. **Application Layer** (`IEMS.Application`)
   - Service implementations
   - DTOs (Data Transfer Objects)
   - Business use cases

3. **Infrastructure Layer** (`IEMS.Infrastructure`)
   - Entity Framework Core DbContext
   - Repository implementations
   - Database migrations and seed data

4. **Presentation Layer** (`IEMS.WPF`)
   - WPF Windows and Views
   - UI logic and data binding
   - User interaction handling

## Usage

### First-Time Setup

1. Launch the application
2. Login with default credentials (admin/Admin@123)
3. Navigate to **User Management** → Change password
4. Configure **System Settings** with your school information
5. Set up **Backup Schedule** for automatic backups

### Common Workflows

#### Adding Students
1. Navigate to **Student Management**
2. Click **Add Student**
3. Fill in student details (all fields required)
4. Click **Save**

#### Recording Fee Payments
1. Go to **Fee Management**
2. Select student and fee type
3. Enter payment details
4. Generate and print receipt

#### Creating Backups
1. Navigate to **Backup & Restore**
2. Click **Create Backup**
3. Choose backup location
4. Backup saved with timestamp

## Deployment

### Creating Distribution Package

```bash
# Creates a self-contained single-file executable for distribution
# -c Release: Build in Release mode for optimized performance
# -r win-x64: Target Windows 64-bit platform
# --self-contained true: Include .NET runtime (no .NET installation required)
# -p:PublishSingleFile=true: Package everything into a single .exe file
# -o: Output directory for the published files
dotnet publish IEMS.WPF/IEMS.WPF.csproj -c Release -r win-x64 --self-contained true -o ./IEMS_Release_Package -p:PublishSingleFile=true
```

**Note**: The main executable is approximately 191MB with bundled .NET runtime. Total package size is ~201MB including WPF dependencies and SQLite.

### Creating Installer (Optional)

1. Install [Inno Setup](https://jrsoftware.org/isinfo.php)
2. Open `CreateInstaller.iss`
3. Compile to generate `IEMS_Setup.exe`
4. Distribute the installer

## Configuration

### Database Connection
- Default: SQLite database in application directory
- Location: `school.db` (auto-created)
- Connection string in `ApplicationDbContext.cs`

### Backup Settings
- Default location: `C:\Users\[Username]\Documents\IEMS_Backups`
- Configurable via System Settings
- Automatic backup schedule supported

## Security Considerations

⚠️ **IMPORTANT**: Please review these security notes before production use:

1. **Default Admin Password**
   - Uses a fixed salt (security risk)
   - **Change immediately** after installation

2. **Password Hashing**
   - Current: PBKDF2 with 10,000 iterations
   - Recommended: Increase to 100,000+ iterations

3. **Database Security**
   - Database stored unencrypted
   - Contains sensitive student/financial data
   - Restrict file access permissions
   - Store backups in secure locations

4. **Authorization**
   - Primarily UI-level checks
   - Ensure only trusted users have access

For detailed security review, see the comprehensive analysis report.

## Troubleshooting

### Application won't start
- Ensure Windows 10/11 64-bit
- Check if antivirus is blocking the .exe
- Add exception to Windows Defender if needed

### Database errors
- Delete `school.db` file (will recreate with default data)
- Or restore from a backup

### "Access Denied" errors
- Run as Administrator
- Or install in a folder with write permissions

## Development

### Running Tests
```bash
dotnet test
```

### Code Style
- Follow C# coding conventions
- Use meaningful variable names
- Add XML documentation for public APIs

### Contributing
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## Version History

- **v1.0** (October 2025)
  - Initial release
  - Core student, teacher, class management
  - Fee payment system
  - Backup & restore functionality
  - User management with authentication

## Support

For issues or questions:
- Check the built-in Help menu
- Review [IEMS-Windows-Requirements.md](IEMS-Windows-Requirements.md)
- Contact your system administrator

## License

This software is provided "AS IS" without warranty of any kind.

## Credits

Developed for Inspire English Medium School, Mardi
Managed by Mahalakmi Bahuddeshiy Sanstha, Chikhalgaon

---

**Build Date**: October 3, 2025
**Framework**: .NET 8.0
**Database**: SQLite
**Platform**: Windows 10/11 (64-bit)
