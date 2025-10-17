# IEMS School Management System

> A comprehensive Windows desktop application for managing school operations, built with .NET 8 and WPF.


## Overview

IEMS (Inspire English Medium School) Management System is a feature-rich desktop application designed to streamline school administration. Built with Clean Architecture principles, it offers offline-first capabilities using SQLite for data persistence.

## Features

### Core Modules

- **Student Management**
  - Complete CRUD operations
  - Bulk student promotion with academic year tracking
  - Aadhaar number integration
  - Excel export functionality
  - Advanced search and filter capabilities
  - Student fee status tracking
  - Leaving certificate generation

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
  - Fee structure management per class and fee type
  - Professional receipt generation and printing
  - Comprehensive payment history tracking
  - Late fee calculations
  - Discount management
  - Academic year integration
  - Fee structure templates
  - Transaction details (Transaction ID, Bank info)
  - Amount in words conversion

- **Finance Management**
  - Electricity bill tracking
  - Other expense management
  - Financial analytics and reporting

- **Transport Management**
  - Vehicle information management (buses, vans)
  - Fuel tracking and consumption
  - Transport expense monitoring
  - Maintenance records
  - Driver details management

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
  - Clear test data functionality

- **Academic Year Management**
  - Create and manage academic years
  - Set active academic year
  - Year-based data filtering
  - Promotion tracking across years

### Document Generation

- **Leaving Certificate**
  - Student details auto-population from database
  - Customizable certificate templates
  - XPS/PDF export options
  - Direct print functionality
  - Integrated within Student Management module

- **Bonafide Certificate**
  - Student verification documents
  - Professional certificate templates
  - Export and print capabilities
  - Quick generation from student records

## Technology Stack

- **Framework**: .NET 8.0
- **UI**: Windows Presentation Foundation (WPF)
- **Database**: SQLite 3
- **ORM**: Entity Framework Core 8.0
- **Architecture**: Clean Architecture with Dependency Injection
- **Authentication**: Custom PBKDF2-based system
- **Excel Export**: ClosedXML library
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection
- **Hosting**: Microsoft.Extensions.Hosting

## System Requirements

- **OS**: Windows 10/11 (64-bit)
- **RAM**: 4 GB minimum, 8 GB recommended
- **Storage**: 500 MB free space
- **.NET**: .NET 8.0 Runtime (for framework-dependent builds)

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

2. **Build and run**

   ```bash
   # Run from source
   dotnet run --project IEMS.WPF

   # Or use convenience scripts
   RunLatest.cmd          # Development build
   PublishAndRun.cmd      # Published version
   ```

3. **Database** is created automatically on first run with sample data


## Project Structure

```
IEMSSchoolManagementSystem/
├── IEMS.Core/                 # Domain entities and interfaces
├── IEMS.Application/          # Business logic and services
├── IEMS.Infrastructure/       # Data access and EF Core
├── IEMS.WPF/                  # WPF UI layer
├── IEMS.Shared/               # Shared utilities
├── IEMS_Release_Package/      # Published application files
├── CreateInstaller.iss        # Inno Setup installer script
├── PublishAndRun.cmd          # Script to publish and run
├── RunLatest.cmd              # Script to run from source
└── school.db                  # SQLite database (auto-generated at runtime)
```


## Usage

1. Launch the application
2. Login with default credentials: **admin** / **Admin@123**
3. **⚠️ Change the default password immediately** in User Management
4. Configure school information in System Settings
5. Set up automatic backup schedule

## Deployment

### Creating Distribution Package

**Method 1: Framework-Dependent (Recommended)**
```bash
# Requires .NET 8.0 Runtime to be installed on target machine
# Results in smaller file size (~5-10 MB)
dotnet publish IEMS.WPF/IEMS.WPF.csproj -c Release -r win-x64 --self-contained false -o ./IEMS_Release_Package
```

**Method 2: Self-Contained (Standalone)**
```bash
# Bundles .NET runtime - no installation needed on target machine
# Results in larger file size (~80-100 MB)
# -c Release: Build in Release mode for optimized performance
# -r win-x64: Target Windows 64-bit platform
# --self-contained true: Include .NET runtime
# -o: Output directory for the published files
dotnet publish IEMS.WPF/IEMS.WPF.csproj -c Release -r win-x64 --self-contained true -o ./IEMS_Release_Package
```

**Note**: The published package includes the executable, dependencies, and required DLLs. Database file (`school.db`) is created at runtime on first launch.


## Configuration

### Database Connection
- Default: SQLite database in application root directory
- Location: `school.db` (auto-created on first run)
- Portable: Can be moved with the application
- Connection string configured in `ApplicationDbContext.cs`

### Backup Settings
- Default location: `C:\Users\[Username]\Documents\IEMS_Backups`
- Configurable via System Settings
- Automatic backup schedule supported

## Security Notes

⚠️ **Important**:
- Change default admin password immediately after installation
- Database is stored unencrypted - restrict file access permissions
- Store backups in secure locations
- Ensure only trusted users have access to the application

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



---

**Developed for**: Inspire English Medium School, Mardi
**Managed by**: Mahalakmi Bahuddeshiy Sanstha, Chikhalgaon
**Version**: 1.0 | **Last Updated**: October 2024
