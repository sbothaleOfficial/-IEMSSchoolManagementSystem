# IEMS School Management System - Windows 10 Requirements Document

**Version**: 1.0
**Date**: September 16, 2025
**Project**: Windows Desktop Port of IEMS Android Application
**Target Platform**: Windows 10/11 Desktop Application

---

## Table of Contents

1. [Executive Summary](#1-executive-summary)
2. [System Overview](#2-system-overview)
3. [Technical Architecture](#3-technical-architecture)
4. [Database Schema](#4-database-schema)
5. [Feature Requirements](#5-feature-requirements)
6. [User Interface Requirements](#6-user-interface-requirements)
7. [Security Requirements](#7-security-requirements)
8. [Performance Requirements](#8-performance-requirements)
9. [System Requirements](#9-system-requirements)
10. [Implementation Guidelines](#10-implementation-guidelines)
11. [Testing Strategy](#11-testing-strategy)
12. [Deployment & Distribution](#12-deployment--distribution)

---

## 1. Executive Summary

### 1.1 Project Overview
The IEMS (Inspire English Medium School) Management System is a comprehensive offline-first school administration application currently running on Android devices. This document outlines the technical requirements for creating a Windows 10 desktop version that maintains full feature parity with the Android application while leveraging Windows-specific capabilities.

### 1.2 Key Features
- **Student Management**: Complete student lifecycle management with fee tracking
- **Employee Management**: HR operations including payroll and attendance
- **Transport Management**: Vehicle fleet and expense tracking
- **Financial Management**: Fee collection, receipts, and expense tracking
- **Attendance System**: Student and employee attendance tracking
- **Reporting & Analytics**: Comprehensive reporting across all modules
- **Multi-language Support**: English and Marathi localization
- **Offline-First Design**: Full functionality without internet connectivity

### 1.3 Target Users
- **School Administrators** (Full system access)
- **Office Staff** (Student and fee management)
- **Clerks** (Expense and operational management)

---

## 2. System Overview

### 2.1 Current Android Implementation
- **Framework**: Jetpack Compose with Kotlin
- **Architecture**: MVVM with Repository pattern
- **Database**: Room SQLite (Version 16)
- **Authentication**: Custom BCrypt-based system
- **Storage**: Local SQLite with 12 core entities

### 2.2 Windows Implementation Goals
- **Maintain Feature Parity**: All Android features in Windows desktop
- **Improve User Experience**: Leverage larger screen real estate
- **Enhanced Performance**: Desktop-class performance and responsiveness
- **Professional Interface**: Windows 11-style modern UI
- **Offline-First**: No internet dependency for core operations

---

## 3. Technical Architecture

### 3.1 Recommended Technology Stack

#### Core Framework
- **UI Framework**: WPF (Windows Presentation Foundation) with .NET 8
- **Alternative**: WinUI 3 for modern Windows 11 styling
- **Programming Language**: C# 12
- **Architecture Pattern**: MVVM (Model-View-ViewModel)

#### Database & ORM
- **Database Engine**: SQLite 3.40+
- **ORM**: Entity Framework Core 8.0
- **Migration Strategy**: Code-First with automatic migrations
- **Connection Management**: Connection pooling with proper disposal

#### Key Dependencies
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
<PackageReference Include="CsvHelper" Version="30.0.1" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
<PackageReference Include="iTextSharp" Version="5.5.13.3" />
<PackageReference Include="Microsoft.Toolkit.Wpf.UI.Controls" Version="6.1.2" />
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.2" />
```

### 3.2 Architecture Layers

#### Presentation Layer (Views)
- **Main Window**: Navigation and layout container
- **User Controls**: Reusable UI components
- **Pages**: Feature-specific screens
- **Converters**: Data binding value converters

#### Business Layer (ViewModels)
- **Command Pattern**: User action handling
- **Observable Properties**: Data binding support
- **Validation Logic**: Input validation and business rules
- **Navigation Services**: Screen navigation management

#### Data Layer (Models & Services)
- **Entity Models**: Database entity representations
- **Repository Pattern**: Data access abstraction
- **Service Layer**: Business logic implementation
- **DTOs**: Data transfer objects for complex operations

---

## 4. Database Schema

### 4.1 Core Entities Overview
The system uses 12 primary entities with well-defined relationships:

1. **Students** - Student information and academic details
2. **Receipts** - Fee payment records
3. **Users** - Authentication and authorization
4. **Employees** - Staff information and management
5. **Vehicles** - Transport fleet management
6. **TransportExpenses** - Vehicle-related expenses
7. **ElectricityExpenses** - Utility expense tracking
8. **OtherExpenses** - General expense management
9. **Attendance** - Employee attendance records
10. **StudentAttendance** - Student attendance tracking
11. **Salaries** - Payroll management
12. **UserSessions** - Session management

### 4.2 Detailed Database Schema

#### Students Table
```sql
CREATE TABLE Students (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    ClassName TEXT NOT NULL,
    ParentPhone TEXT NOT NULL,
    Address TEXT NOT NULL,
    TotalFees REAL NOT NULL,
    PaidFees REAL NOT NULL DEFAULT 0,

    -- ID Card Information
    DateOfBirth TEXT DEFAULT '',
    FatherName TEXT DEFAULT '',
    MotherName TEXT DEFAULT '',
    BloodGroup TEXT DEFAULT '',
    AadhaarNumber TEXT DEFAULT '',

    -- Bonafide Certificate Information
    Caste TEXT DEFAULT '',
    Religion TEXT DEFAULT '',
    JoiningDate TEXT DEFAULT '',
    RollNumber TEXT DEFAULT '',

    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000)
);

-- Computed Properties (implement in C# entity)
-- PendingFees = TotalFees - PaidFees
-- IsFeePending = PendingFees > 0
-- FeeStatusText = IsFeePending ? "Pending" : "Paid"
```

#### Receipts Table
```sql
CREATE TABLE Receipts (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    Amount REAL NOT NULL,
    FeeType TEXT NOT NULL, -- TUITION, ADMISSION, EXAM, TRANSPORT, SPORTS, LIBRARY, UNIFORM, MISCELLANEOUS
    PaymentMethod TEXT NOT NULL, -- CASH, ONLINE, CHEQUE, DD
    TransactionId TEXT,
    ReceiptDate INTEGER NOT NULL,
    AcademicYear TEXT NOT NULL,
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),

    FOREIGN KEY (StudentId) REFERENCES Students (Id) ON DELETE CASCADE
);

CREATE INDEX idx_receipts_student ON Receipts(StudentId);
CREATE INDEX idx_receipts_date ON Receipts(ReceiptDate);
```

#### Users Table (Authentication)
```sql
CREATE TABLE Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT UNIQUE NOT NULL,
    PasswordHash TEXT NOT NULL, -- BCrypt hash with 12 rounds
    Role TEXT NOT NULL, -- ADMIN, STAFF, CLERK
    FullName TEXT NOT NULL,
    Email TEXT,
    IsActive BOOLEAN NOT NULL DEFAULT 1,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    LastLoginAt INTEGER,
    FailedLoginAttempts INTEGER NOT NULL DEFAULT 0,
    LockedUntil INTEGER -- Timestamp for account lockout
);

-- Default Users (to be seeded)
-- Admin: username="sumit.awari", password="sawari@9981"
-- Clerk: username="gambhir.kawade", password="gkawade@7891"
```

#### Employees Table
```sql
CREATE TABLE Employees (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    EmployeeId TEXT UNIQUE NOT NULL,
    FullName TEXT NOT NULL,
    Email TEXT,
    Phone TEXT NOT NULL,
    Address TEXT NOT NULL,
    Category TEXT NOT NULL, -- TEACHER, PEON, DRIVER, OTHER
    Designation TEXT NOT NULL,
    DateOfJoining INTEGER NOT NULL,
    MonthlySalary REAL NOT NULL,
    ContractType TEXT NOT NULL DEFAULT 'PERMANENT', -- PERMANENT, CONTRACT, PART_TIME
    CurrentLoanAmount REAL NOT NULL DEFAULT 0,
    BankAccountNumber TEXT,
    PanNumber TEXT,
    AadharNumber TEXT,
    IsActive BOOLEAN NOT NULL DEFAULT 1,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000)
);

CREATE INDEX idx_employees_category ON Employees(Category);
CREATE INDEX idx_employees_active ON Employees(IsActive);
```

#### Vehicles Table
```sql
CREATE TABLE Vehicles (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    VehicleNumber TEXT UNIQUE NOT NULL,
    VehicleType TEXT NOT NULL, -- BUS, AUTO, TRAVELLER, BIKE
    Model TEXT NOT NULL,
    ManufacturingYear INTEGER,
    SeatingCapacity INTEGER,
    DriverId INTEGER,
    Status TEXT NOT NULL DEFAULT 'ACTIVE', -- ACTIVE, INACTIVE, MAINTENANCE, RETIRED
    InsuranceExpiryDate INTEGER,
    ServiceDueDate INTEGER,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),

    FOREIGN KEY (DriverId) REFERENCES Employees (Id)
);

CREATE INDEX idx_vehicles_status ON Vehicles(Status);
CREATE INDEX idx_vehicles_type ON Vehicles(VehicleType);
```

#### TransportExpenses Table
```sql
CREATE TABLE TransportExpenses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    VehicleId INTEGER NOT NULL,
    Category TEXT NOT NULL, -- FUEL, MAINTENANCE, INSURANCE, SERVICE, REPAIR, PERMIT, TAX, OTHER
    FuelType TEXT, -- DIESEL, PETROL, CNG, ELECTRIC (for fuel expenses)
    Amount REAL NOT NULL,
    Quantity REAL, -- Liters for fuel, units for other items
    PricePerUnit REAL, -- Price per liter/unit
    OdometerReading INTEGER,
    ExpenseDate INTEGER NOT NULL,
    DriverName TEXT,
    VendorName TEXT,
    BillNumber TEXT,
    Description TEXT,
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),

    FOREIGN KEY (VehicleId) REFERENCES Vehicles (Id) ON DELETE CASCADE
);

CREATE INDEX idx_transport_expenses_vehicle ON TransportExpenses(VehicleId);
CREATE INDEX idx_transport_expenses_date ON TransportExpenses(ExpenseDate);
CREATE INDEX idx_transport_expenses_category ON TransportExpenses(Category);
```

#### ElectricityExpenses Table
```sql
CREATE TABLE ElectricityExpenses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Amount REAL NOT NULL,
    MeterReading INTEGER,
    ExpenseDate INTEGER NOT NULL,
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000)
);

CREATE INDEX idx_electricity_expenses_date ON ElectricityExpenses(ExpenseDate);
```

#### OtherExpenses Table
```sql
CREATE TABLE OtherExpenses (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Category TEXT NOT NULL, -- MAINTENANCE, SUPPLIES, UTILITIES, MISCELLANEOUS
    Amount REAL NOT NULL,
    Description TEXT NOT NULL,
    ExpenseDate INTEGER NOT NULL,
    VendorName TEXT,
    BillNumber TEXT,
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000)
);

CREATE INDEX idx_other_expenses_date ON OtherExpenses(ExpenseDate);
CREATE INDEX idx_other_expenses_category ON OtherExpenses(Category);
```

#### Attendance Table (Employee)
```sql
CREATE TABLE Attendance (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    EmployeeId INTEGER NOT NULL,
    Date INTEGER NOT NULL, -- Date in milliseconds (start of day)
    Status TEXT NOT NULL, -- PRESENT, ABSENT, HALF_DAY, LATE, ON_LEAVE
    CheckInTime INTEGER,
    CheckOutTime INTEGER,
    WorkingHours REAL DEFAULT 0,
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),
    UpdatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),

    FOREIGN KEY (EmployeeId) REFERENCES Employees (Id) ON DELETE CASCADE,
    UNIQUE(EmployeeId, Date) -- Prevent duplicate entries for same employee on same date
);

CREATE INDEX idx_attendance_employee ON Attendance(EmployeeId);
CREATE INDEX idx_attendance_date ON Attendance(Date);
```

#### StudentAttendance Table
```sql
CREATE TABLE StudentAttendance (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    Date INTEGER NOT NULL, -- Date in milliseconds (start of day)
    Status TEXT NOT NULL, -- PRESENT, ABSENT, HALF_DAY, LATE
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),

    FOREIGN KEY (StudentId) REFERENCES Students (Id) ON DELETE CASCADE,
    UNIQUE(StudentId, Date) -- Prevent duplicate entries for same student on same date
);

CREATE INDEX idx_student_attendance_student ON StudentAttendance(StudentId);
CREATE INDEX idx_student_attendance_date ON StudentAttendance(Date);
```

#### Salaries Table
```sql
CREATE TABLE Salaries (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    EmployeeId INTEGER NOT NULL,
    Month INTEGER NOT NULL, -- 1-12
    Year INTEGER NOT NULL,
    BasicSalary REAL NOT NULL,
    Allowances REAL DEFAULT 0,
    Deductions REAL DEFAULT 0,
    LoanDeduction REAL DEFAULT 0,
    NetSalary REAL NOT NULL, -- BasicSalary + Allowances - Deductions - LoanDeduction
    PaymentDate INTEGER,
    PaymentMethod TEXT, -- CASH, BANK_TRANSFER, CHEQUE
    Notes TEXT,
    CreatedAt INTEGER NOT NULL DEFAULT (strftime('%s', 'now') * 1000),

    FOREIGN KEY (EmployeeId) REFERENCES Employees (Id) ON DELETE CASCADE,
    UNIQUE(EmployeeId, Month, Year) -- Prevent duplicate salary entries
);

CREATE INDEX idx_salaries_employee ON Salaries(EmployeeId);
CREATE INDEX idx_salaries_period ON Salaries(Year, Month);
```

#### UserSessions Table
```sql
CREATE TABLE UserSessions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    SessionToken TEXT UNIQUE NOT NULL,
    LoginTime INTEGER NOT NULL,
    LogoutTime INTEGER,
    IsActive BOOLEAN NOT NULL DEFAULT 1,

    FOREIGN KEY (UserId) REFERENCES Users (Id) ON DELETE CASCADE
);

CREATE INDEX idx_user_sessions_user ON UserSessions(UserId);
CREATE INDEX idx_user_sessions_token ON UserSessions(SessionToken);
```

### 4.3 Database Versioning & Migration
- **Current Version**: 16 (matching Android implementation)
- **Migration Strategy**: Entity Framework Core migrations
- **Seed Data**: Default admin and clerk users
- **Backup Strategy**: Full database backup before migrations

---

## 5. Feature Requirements

### 5.1 Authentication & Authorization Module

#### 5.1.1 User Roles & Permissions
```csharp
public enum UserRole
{
    ADMIN,    // Full system access
    STAFF,    // Student management + receipts
    CLERK     // Expense management + operations
}
```

**Role-Based Feature Access:**

| Feature | ADMIN | STAFF | CLERK |
|---------|-------|-------|-------|
| Student Management | ✓ | ✓ | ✗ |
| Fee Collection | ✓ | ✓ | ✗ |
| Employee Management | ✓ | ✗ | ✗ |
| Payroll Management | ✓ | ✗ | ✗ |
| Attendance Management | ✓ | ✗ | ✗ |
| Transport Management | ✓ | ✗ | ✓ |
| Expense Management | ✓ | ✗ | ✓ |
| Reports & Analytics | ✓ | Limited | Limited |
| System Settings | ✓ | ✗ | ✗ |
| Backup & Restore | ✓ | ✗ | ✗ |

#### 5.1.2 Authentication Features
- **Secure Login**: Username/password with BCrypt hashing (12 rounds)
- **Account Lockout**: 5 failed attempts = 15-minute lockout
- **Session Management**: Token-based sessions with timeout
- **Password Policy**: Minimum 8 characters, complexity requirements
- **Login Audit**: Track all login attempts and failures

#### 5.1.3 Default Users
```csharp
// Seed data for default users
var defaultUsers = new[]
{
    new User
    {
        Username = "sumit.awari",
        PasswordHash = BCrypt.HashPassword("sawari@9981", 12),
        Role = UserRole.ADMIN,
        FullName = "Sumit Awari",
        IsActive = true
    },
    new User
    {
        Username = "gambhir.kawade",
        PasswordHash = BCrypt.HashPassword("gkawade@7891", 12),
        Role = UserRole.CLERK,
        FullName = "Gambhir Kawade",
        IsActive = true
    }
};
```

### 5.2 Student Management Module

#### 5.2.1 Student Information Structure
```csharp
public class Student
{
    // Basic Information
    public long Id { get; set; }
    public string Name { get; set; }
    public string ClassName { get; set; }
    public string ParentPhone { get; set; }
    public string Address { get; set; }
    public double TotalFees { get; set; }
    public double PaidFees { get; set; }

    // ID Card Information
    public string DateOfBirth { get; set; } = "";
    public string FatherName { get; set; } = "";
    public string MotherName { get; set; } = "";
    public string BloodGroup { get; set; } = "";
    public string AadhaarNumber { get; set; } = "";

    // Bonafide Certificate Information
    public string Caste { get; set; } = "";
    public string Religion { get; set; } = "";
    public string JoiningDate { get; set; } = "";
    public string RollNumber { get; set; } = "";

    // Computed Properties
    public double PendingFees => TotalFees - PaidFees;
    public bool IsFeePending => PendingFees > 0;
    public string FeeStatusText => IsFeePending ? "Pending" : "Paid";

    // Navigation Properties
    public virtual ICollection<Receipt> Receipts { get; set; }
    public virtual ICollection<StudentAttendance> AttendanceRecords { get; set; }
}
```

#### 5.2.2 Core Features
1. **Student Registration**
   - Comprehensive student information form
   - Tab-based interface (Basic Info / ID Card / Bonafide Certificate)
   - Real-time validation with error highlighting
   - Photo upload capability for ID cards
   - Duplicate detection based on name + parent phone

2. **Student Search & Management**
   - Advanced search with multiple criteria (name, class, phone, fee status)
   - Class-wise filtering and sorting
   - Pagination with configurable page sizes (default: 50 students)
   - Bulk operations (export, fee updates, class promotions)
   - Quick statistics (total students, pending fees, collections)

3. **Fee Management Integration**
   - Real-time fee balance calculations
   - Payment history tracking
   - Installment payment support
   - Fee reminder notifications
   - Automated receipt generation

#### 5.2.3 Data Validation Rules
```csharp
public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Student name is required")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters");

        RuleFor(x => x.ClassName)
            .NotEmpty().WithMessage("Class is required")
            .Must(BeValidClass).WithMessage("Invalid class format");

        RuleFor(x => x.ParentPhone)
            .NotEmpty().WithMessage("Parent phone is required")
            .Matches(@"^\d{10}$").WithMessage("Phone must be 10 digits");

        RuleFor(x => x.TotalFees)
            .GreaterThanOrEqualTo(0).WithMessage("Total fees cannot be negative");

        RuleFor(x => x.PaidFees)
            .GreaterThanOrEqualTo(0).WithMessage("Paid fees cannot be negative")
            .LessThanOrEqualTo(x => x.TotalFees).WithMessage("Paid fees cannot exceed total fees");
    }
}
```

### 5.3 Fee Collection & Receipt Management

#### 5.3.1 Fee Types & Structure
```csharp
public enum FeeType
{
    TUITION,        // Monthly tuition fees
    ADMISSION,      // One-time admission fees
    EXAM,          // Examination fees
    TRANSPORT,     // Bus/transport fees
    SPORTS,        // Sports activities
    LIBRARY,       // Library membership
    UNIFORM,       // School uniform
    MISCELLANEOUS  // Other fees
}

public enum PaymentMethod
{
    CASH,          // Cash payment
    ONLINE,        // Online payment (UPI, Net Banking)
    CHEQUE,        // Bank cheque
    DD             // Demand Draft
}
```

#### 5.3.2 Receipt Generation
```csharp
public class Receipt
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public double Amount { get; set; }
    public FeeType FeeType { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string TransactionId { get; set; } // For online payments
    public DateTime ReceiptDate { get; set; }
    public string AcademicYear { get; set; }
    public string Notes { get; set; }

    // Navigation Properties
    public virtual Student Student { get; set; }

    // PDF Generation
    public byte[] GeneratePDF()
    {
        // Implementation using iTextSharp
        // Include school letterhead, student details, payment information
        // Digital signature support
    }
}
```

#### 5.3.3 Receipt PDF Template Requirements
- **Header**: School name, logo, address, contact information
- **Receipt Details**: Receipt number, date, academic year
- **Student Information**: Name, class, roll number, parent phone
- **Payment Details**: Amount, fee type, payment method, transaction ID
- **Footer**: Authorized signature, school seal, terms & conditions
- **Formatting**: Professional layout with proper spacing and alignment

### 5.4 Employee Management & Payroll

#### 5.4.1 Employee Categories & Information
```csharp
public enum EmployeeCategory
{
    TEACHER,    // Teaching staff
    PEON,       // Support staff
    DRIVER,     // Transport drivers
    OTHER       // Administrative and other staff
}

public enum ContractType
{
    PERMANENT,  // Permanent employment
    CONTRACT,   // Contract-based employment
    PART_TIME   // Part-time employment
}

public class Employee
{
    public long Id { get; set; }
    public string EmployeeId { get; set; } // Unique employee identifier
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public EmployeeCategory Category { get; set; }
    public string Designation { get; set; }
    public DateTime DateOfJoining { get; set; }
    public double MonthlySalary { get; set; }
    public ContractType ContractType { get; set; }
    public double CurrentLoanAmount { get; set; }
    public string BankAccountNumber { get; set; }
    public string PanNumber { get; set; }
    public string AadharNumber { get; set; }
    public bool IsActive { get; set; }

    // Navigation Properties
    public virtual ICollection<Attendance> AttendanceRecords { get; set; }
    public virtual ICollection<Salary> SalaryRecords { get; set; }
    public virtual ICollection<Vehicle> AssignedVehicles { get; set; }
}
```

#### 5.4.2 Payroll Management
```csharp
public class Salary
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public int Month { get; set; } // 1-12
    public int Year { get; set; }
    public double BasicSalary { get; set; }
    public double Allowances { get; set; }
    public double Deductions { get; set; }
    public double LoanDeduction { get; set; }
    public double NetSalary { get; set; } // Calculated field
    public DateTime? PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string Notes { get; set; }

    // Navigation Properties
    public virtual Employee Employee { get; set; }

    // Business Logic
    public void CalculateNetSalary()
    {
        NetSalary = BasicSalary + Allowances - Deductions - LoanDeduction;
    }

    // Payslip PDF Generation
    public byte[] GeneratePayslip()
    {
        // Generate PDF payslip with employee details, salary breakdown
        // Include school letterhead and authorized signatures
    }
}
```

#### 5.4.3 Payroll Features
- **Monthly Salary Processing**: Bulk salary generation for all employees
- **Allowances & Deductions**: Configurable allowances and deductions
- **Loan Management**: Track employee loans with automatic deductions
- **Payslip Generation**: PDF payslips with detailed breakdown
- **Payment Tracking**: Record payment dates and methods
- **Salary History**: Complete salary history for each employee
- **Year-end Reports**: Annual salary reports for tax purposes

### 5.5 Attendance Management

#### 5.5.1 Employee Attendance
```csharp
public enum AttendanceStatus
{
    PRESENT,    // Present for full day
    ABSENT,     // Absent for full day
    HALF_DAY,   // Present for half day
    LATE,       // Present but arrived late
    ON_LEAVE    // On approved leave
}

public class Attendance
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public double WorkingHours { get; set; }
    public string Notes { get; set; }

    // Navigation Properties
    public virtual Employee Employee { get; set; }

    // Business Logic
    public void CalculateWorkingHours()
    {
        if (CheckInTime.HasValue && CheckOutTime.HasValue)
        {
            WorkingHours = (CheckOutTime.Value - CheckInTime.Value).TotalHours;
        }
    }
}
```

#### 5.5.2 Student Attendance
```csharp
public class StudentAttendance
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
    public string Notes { get; set; }

    // Navigation Properties
    public virtual Student Student { get; set; }
}
```

#### 5.5.3 Attendance Features
- **Daily Attendance Marking**: Bulk attendance marking with date selection
- **Status Tracking**: Multiple attendance statuses with time tracking
- **Attendance Reports**: Daily, weekly, monthly attendance reports
- **Attendance Analytics**: Attendance percentage calculations
- **Late Arrival Tracking**: Track late arrivals with exact times
- **Leave Management**: Approved leave tracking and reporting

### 5.6 Transport Management

#### 5.6.1 Vehicle Management
```csharp
public enum VehicleType
{
    BUS,        // School bus
    AUTO,       // Auto rickshaw
    TRAVELLER,  // Traveller van
    BIKE        // Motorcycle
}

public enum VehicleStatus
{
    ACTIVE,      // Currently in use
    INACTIVE,    // Not in use
    MAINTENANCE, // Under maintenance
    RETIRED      // Retired from service
}

public class Vehicle
{
    public long Id { get; set; }
    public string VehicleNumber { get; set; } // Unique vehicle registration number
    public VehicleType VehicleType { get; set; }
    public string Model { get; set; }
    public int? ManufacturingYear { get; set; }
    public int? SeatingCapacity { get; set; }
    public long? DriverId { get; set; } // Reference to Employee
    public VehicleStatus Status { get; set; }
    public DateTime? InsuranceExpiryDate { get; set; }
    public DateTime? ServiceDueDate { get; set; }

    // Navigation Properties
    public virtual Employee Driver { get; set; }
    public virtual ICollection<TransportExpense> Expenses { get; set; }

    // Business Logic
    public bool IsInsuranceExpired => InsuranceExpiryDate < DateTime.Now;
    public bool IsServiceDue => ServiceDueDate < DateTime.Now;
    public int DaysUntilInsuranceExpiry => (InsuranceExpiryDate - DateTime.Now)?.Days ?? 0;
    public int DaysUntilService => (ServiceDueDate - DateTime.Now)?.Days ?? 0;
}
```

#### 5.6.2 Transport Expense Management
```csharp
public enum TransportExpenseCategory
{
    FUEL,        // Fuel expenses
    MAINTENANCE, // Vehicle maintenance
    INSURANCE,   // Insurance premiums
    SERVICE,     // Regular servicing
    REPAIR,      // Repair work
    PERMIT,      // Permits and licenses
    TAX,         // Vehicle tax
    OTHER        // Other expenses
}

public enum FuelType
{
    DIESEL,   // Diesel fuel
    PETROL,   // Petrol fuel
    CNG,      // Compressed Natural Gas
    ELECTRIC  // Electric charging
}

public class TransportExpense
{
    public long Id { get; set; }
    public long VehicleId { get; set; }
    public TransportExpenseCategory Category { get; set; }
    public FuelType? FuelType { get; set; } // For fuel expenses
    public double Amount { get; set; }
    public double? Quantity { get; set; } // Liters for fuel
    public double? PricePerUnit { get; set; } // Price per liter/unit
    public int? OdometerReading { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string DriverName { get; set; }
    public string VendorName { get; set; }
    public string BillNumber { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }

    // Navigation Properties
    public virtual Vehicle Vehicle { get; set; }

    // Business Logic
    public bool IsFuelExpense => Category == TransportExpenseCategory.FUEL;
    public double? CalculatedPricePerUnit => Quantity > 0 ? Amount / Quantity : PricePerUnit;
}
```

#### 5.6.3 Transport Features
- **Vehicle Fleet Management**: Complete vehicle lifecycle management
- **Driver Assignment**: Assign drivers from employee database
- **Expense Tracking**: Detailed expense tracking by category
- **Fuel Efficiency**: Calculate fuel efficiency and consumption patterns
- **Maintenance Scheduling**: Track service dates and insurance expiry
- **Route Management**: Plan and optimize transport routes
- **Cost Analysis**: Analyze transport costs per vehicle and route

### 5.7 Expense Management

#### 5.7.1 Electricity Expense Management
```csharp
public class ElectricityExpense
{
    public long Id { get; set; }
    public double Amount { get; set; }
    public int? MeterReading { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string Notes { get; set; }

    // Computed Properties
    public int Month => ExpenseDate.Month;
    public int Year => ExpenseDate.Year;
    public string MonthYear => $"{Year:0000}-{Month:00}";
    public string DisplayDate => ExpenseDate.ToString("dd MMM yyyy");
    public string FormattedAmount => $"₹{Amount:F2}";
}
```

#### 5.7.2 Other Expense Management
```csharp
public enum OtherExpenseCategory
{
    MAINTENANCE,    // Building and equipment maintenance
    SUPPLIES,       // Office and educational supplies
    UTILITIES,      // Water, internet, phone bills
    MISCELLANEOUS   // Other miscellaneous expenses
}

public class OtherExpense
{
    public long Id { get; set; }
    public OtherExpenseCategory Category { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string VendorName { get; set; }
    public string BillNumber { get; set; }
    public string Notes { get; set; }

    // Computed Properties
    public string FormattedAmount => $"₹{Amount:F2}";
    public string DisplayDate => ExpenseDate.ToString("dd MMM yyyy");
}
```

#### 5.7.3 Comprehensive Expense Analytics
- **Category-wise Breakdown**: Expenses grouped by category
- **Monthly Trends**: Track expense patterns over time
- **Budget Management**: Set and track budgets by category
- **Vendor Analysis**: Track expenses by vendor
- **Comparative Analysis**: Year-over-year expense comparisons

### 5.8 Reports & Analytics

#### 5.8.1 Dashboard Statistics
```csharp
public class DashboardStatistics
{
    // Student Statistics
    public int TotalStudents { get; set; }
    public int StudentsWithPendingFees { get; set; }
    public double TotalPendingFees { get; set; }
    public double MonthlyCollections { get; set; }
    public string FormattedPendingFees => $"₹{TotalPendingFees:F2}";
    public string FormattedCollections => $"₹{MonthlyCollections:F2}";

    // Employee Statistics
    public int TotalEmployees { get; set; }
    public int TeachersCount { get; set; }
    public int SupportStaffCount { get; set; }
    public int DriversCount { get; set; }
    public string StaffText => $"{TotalEmployees} Staff";

    // Transport Statistics
    public int ActiveVehicles { get; set; }
    public int VehiclesInMaintenance { get; set; }
    public double MonthlyTransportExpenses { get; set; }
    public string RoutesText => $"{ActiveVehicles} Active";

    // Expense Statistics
    public double MonthlyElectricityExpenses { get; set; }
    public double MonthlyOtherExpenses { get; set; }
    public double TotalMonthlyExpenses { get; set; }
    public string FormattedExpenses => $"₹{TotalMonthlyExpenses:F2}";

    // Payroll Statistics
    public double MonthlyPayrollAmount { get; set; }
    public int EmployeesProcessed { get; set; }
    public string PayrollText => $"₹{MonthlyPayrollAmount:F2}";
}
```

#### 5.8.2 Report Types
1. **Student Reports**
   - Class-wise student lists
   - Fee collection reports
   - Pending fee reports
   - Student attendance reports

2. **Financial Reports**
   - Monthly income statements
   - Expense reports by category
   - Profit and loss statements
   - Fee collection trends

3. **Employee Reports**
   - Employee attendance reports
   - Payroll reports
   - Employee performance reports
   - Leave reports

4. **Transport Reports**
   - Vehicle utilization reports
   - Fuel consumption reports
   - Maintenance cost analysis
   - Route efficiency reports

### 5.9 Data Import/Export

#### 5.9.1 Export Capabilities
```csharp
public enum ExportFormat
{
    JSON,  // JavaScript Object Notation
    CSV    // Comma Separated Values
}

public class ExportResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string FilePath { get; set; }
    public long FileSize { get; set; }
}
```

#### 5.9.2 Import Capabilities
```csharp
public class ImportResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int ImportedCount { get; set; }
    public int DuplicatesFound { get; set; }
    public int ErrorsFound { get; set; }
    public List<string> Errors { get; set; }
}
```

#### 5.9.3 Data Management Features
- **Bulk Student Import**: CSV import with column mapping
- **Data Export**: Export all modules to JSON/CSV
- **Backup & Restore**: Complete database backup and restore
- **Data Validation**: Comprehensive validation during import
- **Duplicate Detection**: Intelligent duplicate detection and handling
- **Progress Tracking**: Real-time import/export progress

---

## 6. User Interface Requirements

### 6.1 Main Application Layout

#### 6.1.1 Navigation Structure
```
IEMS School Management System
├── Dashboard (Home)
├── Student Management
│   ├── Student List
│   ├── Add Student
│   ├── Browse All Students
│   └── Student Reports
├── Fee Management
│   ├── Fee Collection
│   ├── Receipt Generation
│   └── Fee Reports
├── Employee Management (Admin Only)
│   ├── Employee List
│   ├── Add Employee
│   ├── Payroll Management
│   └── Employee Reports
├── Attendance Management (Admin Only)
│   ├── Mark Attendance
│   ├── Attendance Reports
│   └── Attendance Analytics
├── Transport Management
│   ├── Vehicle Management
│   ├── Transport Expenses
│   ├── Route Management
│   └── Transport Reports
├── Expense Management
│   ├── Electricity Expenses
│   ├── Other Expenses
│   ├── Expense Reports
│   └── Budget Management
├── Reports & Analytics
│   ├── Dashboard Reports
│   ├── Financial Reports
│   ├── Operational Reports
│   └── Custom Reports
├── Data Management
│   ├── Import Data
│   ├── Export Data
│   ├── Backup & Restore
│   └── Database Maintenance
└── Settings
    ├── User Management
    ├── School Settings
    ├── System Settings
    └── About
```

#### 6.1.2 Main Window Layout
```xml
<Window x:Class="IEMS.Views.MainWindow">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/> <!-- Title Bar -->
            <RowDefinition Height="Auto"/> <!-- Menu Bar -->
            <RowDefinition Height="*"/>    <!-- Content Area -->
            <RowDefinition Height="Auto"/> <!-- Status Bar -->
        </Grid.RowDefinitions>

        <!-- Title Bar with Logo and User Info -->
        <DockPanel Grid.Row="0" Background="{StaticResource PrimaryBrush}">
            <Image Source="school_logo.png" Width="40" Height="40"/>
            <TextBlock Text="IEMS School Management System" FontSize="18" FontWeight="Bold"/>
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                <TextBlock Text="{Binding CurrentUser.FullName}"/>
                <Button Content="Logout" Command="{Binding LogoutCommand}"/>
            </StackPanel>
        </DockPanel>

        <!-- Navigation Menu -->
        <Menu Grid.Row="1">
            <!-- Menu items based on user role -->
        </Menu>

        <!-- Content Area with Navigation and Main Content -->
        <Grid Grid.Row="2">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="250"/> <!-- Side Navigation -->
                <ColumnDefinition Width="*"/>   <!-- Main Content -->
            </Grid.ColumnDefinitions>

            <!-- Side Navigation Panel -->
            <TreeView Grid.Column="0" ItemsSource="{Binding NavigationItems}"/>

            <!-- Main Content Frame -->
            <Frame Grid.Column="1" NavigationUIVisibility="Hidden" Source="{Binding CurrentPage}"/>
        </Grid>

        <!-- Status Bar -->
        <StatusBar Grid.Row="3">
            <StatusBarItem Content="{Binding StatusMessage}"/>
            <StatusBarItem HorizontalAlignment="Right" Content="{Binding DatabaseStatus}"/>
        </StatusBar>
    </Grid>
</Window>
```

### 6.2 Screen Design Requirements

#### 6.2.1 Dashboard Screen
**Layout Components:**
- **Header Section**: Welcome message, current date/time, quick actions
- **Statistics Cards**: Key metrics with visual indicators
- **Quick Access Panel**: Frequently used features
- **Recent Activity**: Recent transactions and activities
- **Alerts Panel**: Pending tasks, overdue items, system notifications

**Dashboard Cards:**
```xml
<UniformGrid Columns="4" Margin="20">
    <!-- Students Card -->
    <Card Background="LightBlue">
        <StackPanel>
            <TextBlock Text="{Binding TotalStudents}" FontSize="36" FontWeight="Bold"/>
            <TextBlock Text="Total Students" FontSize="14"/>
            <TextBlock Text="{Binding StudentsWithPendingFees}" FontSize="12" Foreground="Red"/>
        </StackPanel>
    </Card>

    <!-- Pending Fees Card -->
    <Card Background="LightCoral">
        <StackPanel>
            <TextBlock Text="{Binding FormattedPendingFees}" FontSize="24" FontWeight="Bold"/>
            <TextBlock Text="Pending Fees" FontSize="14"/>
        </StackPanel>
    </Card>

    <!-- Collections Card -->
    <Card Background="LightGreen">
        <StackPanel>
            <TextBlock Text="{Binding FormattedCollections}" FontSize="24" FontWeight="Bold"/>
            <TextBlock Text="Monthly Collections" FontSize="14"/>
        </StackPanel>
    </Card>

    <!-- Expenses Card -->
    <Card Background="LightYellow">
        <StackPanel>
            <TextBlock Text="{Binding FormattedExpenses}" FontSize="24" FontWeight="Bold"/>
            <TextBlock Text="Monthly Expenses" FontSize="14"/>
        </StackPanel>
    </Card>
</UniformGrid>
```

#### 6.2.2 Student Management Screens

**Student List Screen:**
```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/> <!-- Search and Filters -->
        <RowDefinition Height="*"/>    <!-- Data Grid -->
        <RowDefinition Height="Auto"/> <!-- Pagination -->
    </Grid.RowDefinitions>

    <!-- Search and Filter Panel -->
    <StackPanel Grid.Row="0" Orientation="Horizontal" Margin="10">
        <TextBox x:Name="SearchBox" Width="200" Text="{Binding SearchText}" PlaceholderText="Search students..."/>
        <ComboBox x:Name="ClassFilter" Width="150" ItemsSource="{Binding AvailableClasses}" SelectedItem="{Binding SelectedClass}"/>
        <ComboBox x:Name="FeeStatusFilter" Width="150" ItemsSource="{Binding FeeStatuses}" SelectedItem="{Binding SelectedFeeStatus}"/>
        <Button Content="Search" Command="{Binding SearchCommand}"/>
        <Button Content="Clear" Command="{Binding ClearFiltersCommand}"/>
        <Button Content="Add Student" Command="{Binding AddStudentCommand}" HorizontalAlignment="Right"/>
    </StackPanel>

    <!-- Students Data Grid -->
    <DataGrid Grid.Row="1" ItemsSource="{Binding Students}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" Width="200"/>
            <DataGridTextColumn Header="Class" Binding="{Binding ClassName}" Width="100"/>
            <DataGridTextColumn Header="Parent Phone" Binding="{Binding ParentPhone}" Width="120"/>
            <DataGridTextColumn Header="Total Fees" Binding="{Binding TotalFees, StringFormat=₹{0:F2}}" Width="100"/>
            <DataGridTextColumn Header="Paid Fees" Binding="{Binding PaidFees, StringFormat=₹{0:F2}}" Width="100"/>
            <DataGridTextColumn Header="Pending Fees" Binding="{Binding PendingFees, StringFormat=₹{0:F2}}" Width="100"/>
            <DataGridTextColumn Header="Status" Binding="{Binding FeeStatusText}" Width="80"/>
            <DataGridTemplateColumn Header="Actions" Width="200">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <Button Content="View" Command="{Binding DataContext.ViewStudentCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding}"/>
                            <Button Content="Edit" Command="{Binding DataContext.EditStudentCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding}"/>
                            <Button Content="Receipt" Command="{Binding DataContext.GenerateReceiptCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding}"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>

    <!-- Pagination Controls -->
    <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Margin="10">
        <Button Content="First" Command="{Binding FirstPageCommand}"/>
        <Button Content="Previous" Command="{Binding PreviousPageCommand}"/>
        <TextBlock Text="{Binding CurrentPageInfo}" VerticalAlignment="Center" Margin="10,0"/>
        <Button Content="Next" Command="{Binding NextPageCommand}"/>
        <Button Content="Last" Command="{Binding LastPageCommand}"/>
        <ComboBox ItemsSource="{Binding PageSizes}" SelectedItem="{Binding PageSize}" Width="60" Margin="10,0"/>
    </StackPanel>
</Grid>
```

**Add/Edit Student Screen:**
```xml
<TabControl>
    <!-- Basic Information Tab -->
    <TabItem Header="Basic Information">
        <ScrollViewer>
            <StackPanel Margin="20">
                <TextBox Text="{Binding Student.Name}" Header="Student Name*"/>
                <ComboBox ItemsSource="{Binding AvailableClasses}" SelectedItem="{Binding Student.ClassName}" Header="Class*"/>
                <TextBox Text="{Binding Student.ParentPhone}" Header="Parent Phone*"/>
                <TextBox Text="{Binding Student.Address}" Header="Address*" AcceptsReturn="True" Height="80"/>
                <TextBox Text="{Binding Student.TotalFees}" Header="Total Fees*"/>
                <TextBox Text="{Binding Student.PaidFees}" Header="Paid Fees*"/>
                <TextBlock Text="{Binding Student.PendingFees, StringFormat='Pending Fees: ₹{0:F2}'}" FontWeight="Bold"/>
            </StackPanel>
        </ScrollViewer>
    </TabItem>

    <!-- ID Card Information Tab -->
    <TabItem Header="ID Card Information">
        <ScrollViewer>
            <StackPanel Margin="20">
                <DatePicker SelectedDate="{Binding Student.DateOfBirthAsDate}" Header="Date of Birth"/>
                <TextBox Text="{Binding Student.FatherName}" Header="Father's Name"/>
                <TextBox Text="{Binding Student.MotherName}" Header="Mother's Name"/>
                <ComboBox ItemsSource="{Binding BloodGroups}" SelectedItem="{Binding Student.BloodGroup}" Header="Blood Group"/>
                <TextBox Text="{Binding Student.AadhaarNumber}" Header="Aadhaar Number"/>
            </StackPanel>
        </ScrollViewer>
    </TabItem>

    <!-- Bonafide Certificate Tab -->
    <TabItem Header="Bonafide Certificate">
        <ScrollViewer>
            <StackPanel Margin="20">
                <TextBox Text="{Binding Student.Caste}" Header="Caste"/>
                <TextBox Text="{Binding Student.Religion}" Header="Religion"/>
                <DatePicker SelectedDate="{Binding Student.JoiningDateAsDate}" Header="Joining Date"/>
                <TextBox Text="{Binding Student.RollNumber}" Header="Roll Number"/>
            </StackPanel>
        </ScrollViewer>
    </TabItem>
</TabControl>

<!-- Action Buttons -->
<StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Margin="20">
    <Button Content="Save" Command="{Binding SaveCommand}" Style="{StaticResource PrimaryButton}"/>
    <Button Content="Cancel" Command="{Binding CancelCommand}" Style="{StaticResource SecondaryButton}"/>
</StackPanel>
```

#### 6.2.3 Employee Management Screens

**Employee List Screen:**
- Similar layout to Student List with employee-specific columns
- Category-based filtering (Teachers, Peons, Drivers, Others)
- Salary information and employment status
- Actions: View, Edit, Generate Payslip, Mark Attendance

**Payroll Management Screen:**
```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/> <!-- Month/Year Selection -->
        <RowDefinition Height="*"/>    <!-- Employee Salary Grid -->
        <RowDefinition Height="Auto"/> <!-- Action Buttons -->
    </Grid.RowDefinitions>

    <!-- Month/Year Selection -->
    <StackPanel Grid.Row="0" Orientation="Horizontal" Margin="10">
        <ComboBox ItemsSource="{Binding Months}" SelectedItem="{Binding SelectedMonth}" Width="100"/>
        <ComboBox ItemsSource="{Binding Years}" SelectedItem="{Binding SelectedYear}" Width="80"/>
        <Button Content="Load Payroll" Command="{Binding LoadPayrollCommand}"/>
        <Button Content="Process All" Command="{Binding ProcessAllCommand}" HorizontalAlignment="Right"/>
    </StackPanel>

    <!-- Salary Data Grid -->
    <DataGrid Grid.Row="1" ItemsSource="{Binding EmployeeSalaries}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Employee ID" Binding="{Binding Employee.EmployeeId}"/>
            <DataGridTextColumn Header="Name" Binding="{Binding Employee.FullName}"/>
            <DataGridTextColumn Header="Designation" Binding="{Binding Employee.Designation}"/>
            <DataGridTextColumn Header="Basic Salary" Binding="{Binding BasicSalary, StringFormat=₹{0:F2}}"/>
            <DataGridTextColumn Header="Allowances" Binding="{Binding Allowances, StringFormat=₹{0:F2}}"/>
            <DataGridTextColumn Header="Deductions" Binding="{Binding Deductions, StringFormat=₹{0:F2}}"/>
            <DataGridTextColumn Header="Loan Deduction" Binding="{Binding LoanDeduction, StringFormat=₹{0:F2}}"/>
            <DataGridTextColumn Header="Net Salary" Binding="{Binding NetSalary, StringFormat=₹{0:F2}}"/>
            <DataGridTemplateColumn Header="Status">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding PaymentStatus}" Foreground="{Binding PaymentStatusColor}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Actions">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <Button Content="Process" Command="{Binding DataContext.ProcessSalaryCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding}"/>
                            <Button Content="Payslip" Command="{Binding DataContext.GeneratePayslipCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}" CommandParameter="{Binding}"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>

    <!-- Summary Panel -->
    <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Right" Margin="10">
        <TextBlock Text="{Binding TotalPayrollAmount, StringFormat='Total Payroll: ₹{0:F2}'}" FontSize="16" FontWeight="Bold"/>
        <Button Content="Export Report" Command="{Binding ExportReportCommand}" Margin="10,0"/>
    </StackPanel>
</Grid>
```

#### 6.2.4 Transport Management Screens

**Transport Dashboard:**
- Vehicle status overview with visual indicators
- Fuel consumption charts and trends
- Maintenance alerts and reminders
- Route efficiency metrics

**Vehicle Management:**
- Vehicle list with status indicators
- Maintenance scheduling calendar
- Expense tracking per vehicle
- Driver assignment management

### 6.3 Multi-Language Support

#### 6.3.1 Localization Architecture
```csharp
public class LocalizationService
{
    private readonly Dictionary<string, Dictionary<string, string>> _resources;

    public string GetString(string key, string language = "en")
    {
        if (_resources.ContainsKey(language) && _resources[language].ContainsKey(key))
        {
            return _resources[language][key];
        }

        // Fallback to English
        return _resources["en"]?.GetValueOrDefault(key, key) ?? key;
    }
}
```

#### 6.3.2 Language Resources
**English (en.json):**
```json
{
    "app_name": "IEMS School Management System",
    "dashboard": "Dashboard",
    "student_management": "Student Management",
    "employee_management": "Employee Management",
    "transport_management": "Transport Management",
    "expense_management": "Expense Management",
    "reports": "Reports",
    "settings": "Settings",
    "add_student": "Add Student",
    "edit_student": "Edit Student",
    "student_name": "Student Name",
    "class": "Class",
    "parent_phone": "Parent Phone",
    "address": "Address",
    "total_fees": "Total Fees",
    "paid_fees": "Paid Fees",
    "pending_fees": "Pending Fees",
    "save": "Save",
    "cancel": "Cancel",
    "delete": "Delete",
    "search": "Search",
    "filter": "Filter"
}
```

**Marathi (mr.json):**
```json
{
    "app_name": "आयईएमएस शाळा व्यवस्थापन प्रणाली",
    "dashboard": "डॅशबोर्ड",
    "student_management": "विद्यार्थी व्यवस्थापन",
    "employee_management": "कर्मचारी व्यवस्थापन",
    "transport_management": "वाहतूक व्यवस्थापन",
    "expense_management": "खर्च व्यवस्थापन",
    "reports": "अहवाल",
    "settings": "सेटिंग्ज",
    "add_student": "विद्यार्थी जोडा",
    "edit_student": "विद्यार्थी संपादित करा",
    "student_name": "विद्यार्थ्याचे नाव",
    "class": "वर्ग",
    "parent_phone": "पालकांचा फोन",
    "address": "पत्ता",
    "total_fees": "एकूण फी",
    "paid_fees": "भरलेली फी",
    "pending_fees": "प्रलंबित फी",
    "save": "जतन करा",
    "cancel": "रद्द करा",
    "delete": "हटवा",
    "search": "शोधा",
    "filter": "फिल्टर"
}
```

#### 6.3.3 Runtime Language Switching
```csharp
public class LanguageManager : INotifyPropertyChanged
{
    private string _currentLanguage = "en";

    public string CurrentLanguage
    {
        get => _currentLanguage;
        set
        {
            _currentLanguage = value;
            OnPropertyChanged();
            LanguageChanged?.Invoke(value);
        }
    }

    public event Action<string> LanguageChanged;
    public event PropertyChangedEventHandler PropertyChanged;

    public void ToggleLanguage()
    {
        CurrentLanguage = CurrentLanguage == "en" ? "mr" : "en";
    }
}
```

---

## 7. Security Requirements

### 7.1 Authentication Security

#### 7.1.1 Password Security
```csharp
public class PasswordSecurity
{
    private const int BcryptRounds = 12;

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, BcryptRounds);
    }

    public static bool VerifyPassword(string password, string hash)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        catch
        {
            return false;
        }
    }

    public static bool IsStrongPassword(string password)
    {
        return password.Length >= 8 &&
               password.Any(char.IsUpper) &&
               password.Any(char.IsLower) &&
               password.Any(char.IsDigit) &&
               password.Any(c => !char.IsLetterOrDigit(c));
    }
}
```

#### 7.1.2 Account Security
```csharp
public class AccountSecurity
{
    private const int MaxFailedAttempts = 5;
    private const int LockoutDurationMinutes = 15;

    public async Task<LoginResult> AuthenticateUser(string username, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(username);

        if (user == null)
            return new LoginResult { Success = false, Message = "Invalid credentials" };

        if (!user.IsActive)
            return new LoginResult { Success = false, Message = "Account is deactivated" };

        if (IsAccountLocked(user))
            return new LoginResult { Success = false, Message = "Account is temporarily locked" };

        if (!PasswordSecurity.VerifyPassword(password, user.PasswordHash))
        {
            await IncrementFailedAttempts(user);
            return new LoginResult { Success = false, Message = "Invalid credentials" };
        }

        await ResetFailedAttempts(user);
        await UpdateLastLogin(user);

        return new LoginResult { Success = true, User = user };
    }

    private bool IsAccountLocked(User user)
    {
        return user.LockedUntil.HasValue && user.LockedUntil > DateTime.UtcNow;
    }

    private async Task IncrementFailedAttempts(User user)
    {
        user.FailedLoginAttempts++;

        if (user.FailedLoginAttempts >= MaxFailedAttempts)
        {
            user.LockedUntil = DateTime.UtcNow.AddMinutes(LockoutDurationMinutes);
        }

        await _userRepository.UpdateAsync(user);
    }
}
```

### 7.2 Session Management

#### 7.2.1 Session Security
```csharp
public class SessionManager
{
    private const int SessionTimeoutMinutes = 60;

    public async Task<string> CreateSession(User user)
    {
        var sessionToken = GenerateSecureToken();

        var session = new UserSession
        {
            UserId = user.Id,
            SessionToken = sessionToken,
            LoginTime = DateTime.UtcNow,
            IsActive = true
        };

        await _sessionRepository.CreateAsync(session);
        return sessionToken;
    }

    public async Task<bool> ValidateSession(string sessionToken)
    {
        var session = await _sessionRepository.GetByTokenAsync(sessionToken);

        if (session == null || !session.IsActive)
            return false;

        if (session.LoginTime.AddMinutes(SessionTimeoutMinutes) < DateTime.UtcNow)
        {
            await InvalidateSession(sessionToken);
            return false;
        }

        return true;
    }

    private string GenerateSecureToken()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var bytes = new byte[32];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
```

### 7.3 Data Protection

#### 7.3.1 Local Data Encryption
```csharp
public class DataProtection
{
    public static string EncryptSensitiveData(string data)
    {
        return ProtectedData.Protect(
            Encoding.UTF8.GetBytes(data),
            null,
            DataProtectionScope.CurrentUser
        ).ToBase64();
    }

    public static string DecryptSensitiveData(string encryptedData)
    {
        var bytes = Convert.FromBase64String(encryptedData);
        var decryptedBytes = ProtectedData.Unprotect(
            bytes,
            null,
            DataProtectionScope.CurrentUser
        );
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
```

#### 7.3.2 Database Security
```csharp
public class DatabaseSecurity
{
    public static string GetSecureConnectionString()
    {
        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = GetDatabasePath(),
            Password = GetDatabasePassword(),
            Cache = SqliteCacheMode.Shared,
            Mode = SqliteOpenMode.ReadWriteCreate
        };

        return builder.ConnectionString;
    }

    private static string GetDatabasePassword()
    {
        // Generate or retrieve secure database password
        // Store in Windows Credential Manager or similar secure storage
        return GenerateOrRetrievePassword();
    }
}
```

### 7.4 Audit Logging

#### 7.4.1 Security Audit Log
```csharp
public class SecurityAuditLogger
{
    public async Task LogSecurityEvent(SecurityEvent securityEvent)
    {
        var logEntry = new AuditLog
        {
            Timestamp = DateTime.UtcNow,
            UserId = securityEvent.UserId,
            Action = securityEvent.Action,
            Details = securityEvent.Details,
            IPAddress = GetLocalIPAddress(),
            Success = securityEvent.Success
        };

        await _auditRepository.CreateAsync(logEntry);
    }

    public async Task LogLoginAttempt(string username, bool success, string details = null)
    {
        await LogSecurityEvent(new SecurityEvent
        {
            Action = "LOGIN_ATTEMPT",
            Details = $"Username: {username}, Success: {success}, Details: {details}",
            Success = success
        });
    }

    public async Task LogDataAccess(long userId, string entityType, string action, long? entityId = null)
    {
        await LogSecurityEvent(new SecurityEvent
        {
            UserId = userId,
            Action = $"DATA_ACCESS_{action.ToUpper()}",
            Details = $"Entity: {entityType}, ID: {entityId}",
            Success = true
        });
    }
}
```

---

## 8. Performance Requirements

### 8.1 Application Performance

#### 8.1.1 Response Time Requirements
| Operation Type | Target Response Time | Maximum Acceptable |
|---------------|---------------------|-------------------|
| Application Startup | < 3 seconds | < 5 seconds |
| Login Authentication | < 1 second | < 2 seconds |
| Dashboard Load | < 2 seconds | < 3 seconds |
| Student Search | < 500ms | < 1 second |
| Add/Edit Student | < 1 second | < 2 seconds |
| Report Generation | < 5 seconds | < 10 seconds |
| PDF Generation | < 3 seconds | < 5 seconds |
| Database Backup | < 30 seconds | < 60 seconds |

#### 8.1.2 Memory Usage
- **Initial Memory**: < 100MB
- **Maximum Memory**: < 500MB under normal load
- **Memory Growth**: < 10MB per hour during continuous use
- **Memory Cleanup**: Automatic garbage collection every 10 minutes

#### 8.1.3 Database Performance
```csharp
public class DatabaseOptimizer
{
    public void OptimizeDatabase()
    {
        // Create indexes for frequently queried columns
        CreateIndexes();

        // Analyze query execution plans
        AnalyzeQueries();

        // Clean up old data
        CleanupOldData();

        // Vacuum database to reclaim space
        VacuumDatabase();
    }

    private void CreateIndexes()
    {
        var indexes = new[]
        {
            "CREATE INDEX IF NOT EXISTS idx_students_class ON Students(ClassName)",
            "CREATE INDEX IF NOT EXISTS idx_students_name ON Students(Name)",
            "CREATE INDEX IF NOT EXISTS idx_receipts_date ON Receipts(ReceiptDate)",
            "CREATE INDEX IF NOT EXISTS idx_receipts_student ON Receipts(StudentId)",
            "CREATE INDEX IF NOT EXISTS idx_employees_category ON Employees(Category)",
            "CREATE INDEX IF NOT EXISTS idx_attendance_date ON Attendance(Date)",
            "CREATE INDEX IF NOT EXISTS idx_expenses_date ON TransportExpenses(ExpenseDate)"
        };

        foreach (var index in indexes)
        {
            ExecuteNonQuery(index);
        }
    }
}
```

### 8.2 Scalability Requirements

#### 8.2.1 Data Capacity
- **Students**: Support up to 10,000 active students
- **Employees**: Support up to 1,000 employees
- **Vehicles**: Support up to 100 vehicles
- **Transactions**: Support up to 1,000,000 transactions over 5 years
- **Reports**: Generate reports for up to 10,000 records
- **Concurrent Users**: Support up to 10 concurrent users on network deployment

#### 8.2.2 Performance Optimization Strategies
```csharp
public class PerformanceOptimizer
{
    // Implement caching for frequently accessed data
    private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions
    {
        SizeLimit = 1000
    });

    public async Task<List<Student>> GetStudentsWithCaching(int page, int pageSize)
    {
        var cacheKey = $"students_page_{page}_{pageSize}";

        if (_cache.TryGetValue(cacheKey, out List<Student> cachedStudents))
        {
            return cachedStudents;
        }

        var students = await _studentRepository.GetPagedAsync(page, pageSize);

        _cache.Set(cacheKey, students, TimeSpan.FromMinutes(5));

        return students;
    }

    // Implement lazy loading for large collections
    public IQueryable<Student> GetStudentsLazy()
    {
        return _context.Students
            .AsNoTracking() // Disable change tracking for read-only scenarios
            .OrderBy(s => s.Name);
    }

    // Implement bulk operations for better performance
    public async Task BulkInsertStudents(List<Student> students)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.Students.AddRangeAsync(students);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
```

### 8.3 Resource Management

#### 8.3.1 Memory Management
```csharp
public class ResourceManager : IDisposable
{
    private readonly Timer _cleanupTimer;
    private bool _disposed = false;

    public ResourceManager()
    {
        // Run cleanup every 10 minutes
        _cleanupTimer = new Timer(Cleanup, null, TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10));
    }

    private void Cleanup(object state)
    {
        // Force garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Clear caches
        ClearCaches();

        // Log memory usage
        LogMemoryUsage();
    }

    private void LogMemoryUsage()
    {
        var process = Process.GetCurrentProcess();
        var memoryUsage = process.WorkingSet64 / 1024 / 1024; // MB

        Logger.Information($"Memory usage: {memoryUsage} MB");

        if (memoryUsage > 400) // Warning threshold
        {
            Logger.Warning($"High memory usage detected: {memoryUsage} MB");
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _cleanupTimer?.Dispose();
            _disposed = true;
        }
    }
}
```

---

## 9. System Requirements

### 9.1 Hardware Requirements

#### 9.1.1 Minimum System Requirements
- **Operating System**: Windows 10 version 1903 (Build 18362) or later
- **Processor**: Intel Core i3 or AMD equivalent (2.0 GHz or faster)
- **Memory**: 4 GB RAM
- **Storage**: 2 GB available disk space
- **Display**: 1366 x 768 screen resolution
- **Network**: Not required (offline-first application)

#### 9.1.2 Recommended System Requirements
- **Operating System**: Windows 11 or Windows 10 version 21H2 or later
- **Processor**: Intel Core i5 or AMD equivalent (2.5 GHz or faster)
- **Memory**: 8 GB RAM or more
- **Storage**: 5 GB available disk space (SSD preferred)
- **Display**: 1920 x 1080 screen resolution or higher
- **Network**: Optional for updates and cloud backup

#### 9.1.3 Performance Considerations
- **SSD Storage**: Recommended for faster database operations
- **Multiple Monitors**: Supported for enhanced productivity
- **Touch Screen**: Optional touch support for modern devices
- **Printer**: Required for receipt and report printing

### 9.2 Software Dependencies

#### 9.2.1 Runtime Dependencies
```xml
<PackageReference Include="Microsoft.WindowsDesktop.App" Version="8.0.0" />
<PackageReference Include="Microsoft.NETCore.App" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="System.Data.SQLite" Version="1.0.118" />
```

#### 9.2.2 Development Dependencies
```xml
<PackageReference Include="Microsoft.NET.Sdk.WindowsDesktop" Version="8.0.0" />
<PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.19.4" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="8.0.0" />
```

### 9.3 Database Requirements

#### 9.3.1 SQLite Configuration
```csharp
public class DatabaseConfiguration
{
    public static string GetConnectionString()
    {
        var databasePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "IEMS",
            "Database",
            "iems_school.db"
        );

        Directory.CreateDirectory(Path.GetDirectoryName(databasePath));

        return new SqliteConnectionStringBuilder
        {
            DataSource = databasePath,
            Cache = SqliteCacheMode.Shared,
            Mode = SqliteOpenMode.ReadWriteCreate,
            Pooling = true
        }.ConnectionString;
    }
}
```

#### 9.3.2 Database Storage
- **Initial Size**: ~10 MB empty database
- **Growth Rate**: ~100 MB per 1000 students with full data
- **Maximum Size**: 1 TB (SQLite limitation)
- **Backup Size**: Compressed backup ~30% of original size

---

## 10. Implementation Guidelines

### 10.1 Project Structure

#### 10.1.1 Solution Architecture
```
IEMS.WindowsApp/
├── IEMS.Core/                    # Core business logic
│   ├── Entities/                 # Database entities
│   ├── Interfaces/               # Repository and service interfaces
│   ├── Services/                 # Business logic services
│   └── DTOs/                     # Data transfer objects
├── IEMS.Infrastructure/          # Data access layer
│   ├── Data/                     # Entity Framework context
│   ├── Repositories/             # Repository implementations
│   ├── Migrations/               # Database migrations
│   └── Configurations/           # Entity configurations
├── IEMS.Application/             # Application layer
│   ├── ViewModels/               # MVVM ViewModels
│   ├── Commands/                 # Command implementations
│   ├── Converters/               # Value converters
│   └── Services/                 # Application services
├── IEMS.WPF/                     # WPF presentation layer
│   ├── Views/                    # WPF windows and user controls
│   ├── Styles/                   # WPF styles and templates
│   ├── Resources/                # Images, icons, localization
│   └── Controls/                 # Custom WPF controls
├── IEMS.Shared/                  # Shared utilities
│   ├── Constants/                # Application constants
│   ├── Extensions/               # Extension methods
│   ├── Helpers/                  # Utility classes
│   └── Models/                   # Shared models
└── IEMS.Tests/                   # Unit and integration tests
    ├── Unit/                     # Unit tests
    ├── Integration/              # Integration tests
    └── TestData/                 # Test data fixtures
```

#### 10.1.2 Dependency Injection Setup
```csharp
public class ServiceConfigurator
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        // Database context
        services.AddDbContext<IEMSDbContext>(options =>
            options.UseSqlite(DatabaseConfiguration.GetConnectionString()));

        // Repositories
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IReceiptRepository, ReceiptRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IReportService, ReportService>();

        // ViewModels
        services.AddTransient<MainViewModel>();
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<StudentListViewModel>();
        services.AddTransient<StudentDetailViewModel>();

        // Utilities
        services.AddSingleton<ILocalizationService, LocalizationService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IDialogService, DialogService>();

        return services;
    }
}
```

### 10.2 MVVM Implementation

#### 10.2.1 Base ViewModel
```csharp
public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
```

#### 10.2.2 Async Command Implementation
```csharp
public class AsyncRelayCommand : ICommand
{
    private readonly Func<object, Task> _execute;
    private readonly Predicate<object> _canExecute;
    private bool _isExecuting;

    public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute = null)
        : this(execute != null ? _ => execute() : null, canExecute != null ? _ => canExecute() : null)
    {
    }

    public AsyncRelayCommand(Func<object, Task> execute, Predicate<object> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter)
    {
        return !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);
    }

    public async void Execute(object parameter)
    {
        if (!CanExecute(parameter))
            return;

        _isExecuting = true;
        RaiseCanExecuteChanged();

        try
        {
            await _execute(parameter);
        }
        catch (Exception ex)
        {
            // Handle exception (logging, user notification, etc.)
            HandleException(ex);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged()
    {
        CommandManager.InvalidateRequerySuggested();
    }

    private void HandleException(Exception ex)
    {
        // Log exception and show user-friendly error message
        Logger.LogError(ex, "Command execution failed");
        // Show error dialog to user
    }
}
```

### 10.3 Data Access Implementation

#### 10.3.1 Repository Pattern
```csharp
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(long id);
    Task<bool> ExistsAsync(long id);
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly IEMSDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(IEMSDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<T> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task DeleteAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public virtual async Task<bool> ExistsAsync(long id)
    {
        return await _dbSet.FindAsync(id) != null;
    }
}
```

#### 10.3.2 Student Repository Implementation
```csharp
public interface IStudentRepository : IRepository<Student>
{
    Task<PagedResult<Student>> GetPagedAsync(int page, int pageSize, string searchTerm = null, string className = null, bool? hasePendingFees = null);
    Task<List<Student>> GetByClassAsync(string className);
    Task<Student> GetByNameAndPhoneAsync(string name, string phone);
    Task<List<Student>> GetStudentsWithPendingFeesAsync();
    Task<double> GetTotalPendingFeesAsync();
    Task<double> GetTotalCollectionsForMonthAsync(int year, int month);
}

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(IEMSDbContext context) : base(context) { }

    public async Task<PagedResult<Student>> GetPagedAsync(int page, int pageSize, string searchTerm = null, string className = null, bool? hasPendingFees = null)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(s => s.Name.Contains(searchTerm) || s.ParentPhone.Contains(searchTerm));
        }

        if (!string.IsNullOrEmpty(className))
        {
            query = query.Where(s => s.ClassName == className);
        }

        if (hasPendingFees.HasValue)
        {
            if (hasPendingFees.Value)
                query = query.Where(s => s.TotalFees > s.PaidFees);
            else
                query = query.Where(s => s.TotalFees <= s.PaidFees);
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .OrderBy(s => s.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Student>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }

    public async Task<List<Student>> GetByClassAsync(string className)
    {
        return await _dbSet
            .Where(s => s.ClassName == className)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<Student> GetByNameAndPhoneAsync(string name, string phone)
    {
        return await _dbSet
            .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower() && s.ParentPhone == phone);
    }

    public async Task<List<Student>> GetStudentsWithPendingFeesAsync()
    {
        return await _dbSet
            .Where(s => s.TotalFees > s.PaidFees)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<double> GetTotalPendingFeesAsync()
    {
        return await _dbSet
            .Where(s => s.TotalFees > s.PaidFees)
            .SumAsync(s => s.TotalFees - s.PaidFees);
    }

    public async Task<double> GetTotalCollectionsForMonthAsync(int year, int month)
    {
        var startOfMonth = new DateTime(year, month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        return await _context.Receipts
            .Where(r => r.ReceiptDate >= startOfMonth && r.ReceiptDate <= endOfMonth)
            .SumAsync(r => r.Amount);
    }
}
```

### 10.4 PDF Generation Implementation

#### 10.4.1 Receipt PDF Generator
```csharp
public class ReceiptPDFGenerator
{
    public byte[] GenerateReceipt(Receipt receipt, Student student)
    {
        using (var memoryStream = new MemoryStream())
        {
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            // Add school header
            AddSchoolHeader(document);

            // Add receipt details
            AddReceiptDetails(document, receipt, student);

            // Add payment information
            AddPaymentInformation(document, receipt);

            // Add footer
            AddFooter(document);

            document.Close();

            return memoryStream.ToArray();
        }
    }

    private void AddSchoolHeader(Document document)
    {
        var headerTable = new PdfPTable(2) { WidthPercentage = 100 };
        headerTable.SetWidths(new float[] { 1, 3 });

        // School logo
        var logoCell = new PdfPCell();
        // Add logo image if available

        // School information
        var schoolInfoCell = new PdfPCell();
        var schoolInfo = new Paragraph();
        schoolInfo.Add(new Chunk("INSPIRE ENGLISH MEDIUM SCHOOL\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
        schoolInfo.Add(new Chunk("Adharwadi Kalyan, Thane - 421301\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
        schoolInfo.Add(new Chunk("Phone: +91 9876543210\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
        schoolInfo.Add(new Chunk("Email: info@iems.edu\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));

        schoolInfoCell.AddElement(schoolInfo);
        schoolInfoCell.Border = Rectangle.NO_BORDER;

        headerTable.AddCell(logoCell);
        headerTable.AddCell(schoolInfoCell);

        document.Add(headerTable);
        document.Add(new Paragraph("\n"));
    }

    private void AddReceiptDetails(Document document, Receipt receipt, Student student)
    {
        var receiptTitle = new Paragraph("FEE RECEIPT", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
        receiptTitle.Alignment = Element.ALIGN_CENTER;
        document.Add(receiptTitle);
        document.Add(new Paragraph("\n"));

        var detailsTable = new PdfPTable(4) { WidthPercentage = 100 };
        detailsTable.SetWidths(new float[] { 1, 2, 1, 2 });

        // Receipt details
        AddTableCell(detailsTable, "Receipt No:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
        AddTableCell(detailsTable, receipt.Id.ToString("D6"), FontFactory.GetFont(FontFactory.HELVETICA, 10));
        AddTableCell(detailsTable, "Date:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
        AddTableCell(detailsTable, receipt.ReceiptDate.ToString("dd/MM/yyyy"), FontFactory.GetFont(FontFactory.HELVETICA, 10));

        AddTableCell(detailsTable, "Student Name:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
        AddTableCell(detailsTable, student.Name, FontFactory.GetFont(FontFactory.HELVETICA, 10));
        AddTableCell(detailsTable, "Class:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
        AddTableCell(detailsTable, student.ClassName, FontFactory.GetFont(FontFactory.HELVETICA, 10));

        AddTableCell(detailsTable, "Parent Phone:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
        AddTableCell(detailsTable, student.ParentPhone, FontFactory.GetFont(FontFactory.HELVETICA, 10));
        AddTableCell(detailsTable, "Academic Year:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10));
        AddTableCell(detailsTable, receipt.AcademicYear, FontFactory.GetFont(FontFactory.HELVETICA, 10));

        document.Add(detailsTable);
        document.Add(new Paragraph("\n"));
    }

    private void AddPaymentInformation(Document document, Receipt receipt)
    {
        var paymentTable = new PdfPTable(2) { WidthPercentage = 100 };
        paymentTable.SetWidths(new float[] { 3, 1 });

        // Payment details header
        var headerCell1 = new PdfPCell(new Phrase("PAYMENT DETAILS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
        headerCell1.Colspan = 2;
        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
        headerCell1.BackgroundColor = BaseColor.LIGHT_GRAY;
        paymentTable.AddCell(headerCell1);

        // Fee type and amount
        AddTableCell(paymentTable, $"Fee Type: {receipt.FeeType}", FontFactory.GetFont(FontFactory.HELVETICA, 11));
        AddTableCell(paymentTable, $"₹{receipt.Amount:F2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));

        // Payment method
        AddTableCell(paymentTable, $"Payment Method: {receipt.PaymentMethod}", FontFactory.GetFont(FontFactory.HELVETICA, 10));
        AddTableCell(paymentTable, "", FontFactory.GetFont(FontFactory.HELVETICA, 10));

        if (!string.IsNullOrEmpty(receipt.TransactionId))
        {
            AddTableCell(paymentTable, $"Transaction ID: {receipt.TransactionId}", FontFactory.GetFont(FontFactory.HELVETICA, 10));
            AddTableCell(paymentTable, "", FontFactory.GetFont(FontFactory.HELVETICA, 10));
        }

        // Total amount
        var totalCell1 = new PdfPCell(new Phrase("TOTAL AMOUNT", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
        totalCell1.BackgroundColor = BaseColor.LIGHT_GRAY;
        var totalCell2 = new PdfPCell(new Phrase($"₹{receipt.Amount:F2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
        totalCell2.BackgroundColor = BaseColor.LIGHT_GRAY;

        paymentTable.AddCell(totalCell1);
        paymentTable.AddCell(totalCell2);

        document.Add(paymentTable);
    }

    private void AddFooter(Document document)
    {
        document.Add(new Paragraph("\n\n"));

        var footerTable = new PdfPTable(2) { WidthPercentage = 100 };

        var termsCell = new PdfPCell();
        var terms = new Paragraph();
        terms.Add(new Chunk("Terms & Conditions:\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));
        terms.Add(new Chunk("1. Fees once paid will not be refunded.\n", FontFactory.GetFont(FontFactory.HELVETICA, 7)));
        terms.Add(new Chunk("2. Please keep this receipt for future reference.\n", FontFactory.GetFont(FontFactory.HELVETICA, 7)));
        terms.Add(new Chunk("3. For any queries, contact school office.\n", FontFactory.GetFont(FontFactory.HELVETICA, 7)));

        termsCell.AddElement(terms);
        termsCell.Border = Rectangle.NO_BORDER;

        var signatureCell = new PdfPCell();
        var signature = new Paragraph();
        signature.Add(new Chunk("\n\n\n_______________________\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
        signature.Add(new Chunk("Authorized Signature", FontFactory.GetFont(FontFactory.HELVETICA, 9)));
        signature.Alignment = Element.ALIGN_CENTER;

        signatureCell.AddElement(signature);
        signatureCell.Border = Rectangle.NO_BORDER;

        footerTable.AddCell(termsCell);
        footerTable.AddCell(signatureCell);

        document.Add(footerTable);
    }

    private void AddTableCell(PdfPTable table, string text, Font font)
    {
        var cell = new PdfPCell(new Phrase(text, font));
        cell.Border = Rectangle.NO_BORDER;
        cell.PaddingBottom = 5f;
        table.AddCell(cell);
    }
}
```

---

## 11. Testing Strategy

### 11.1 Unit Testing

#### 11.1.1 Repository Testing
```csharp
[TestClass]
public class StudentRepositoryTests
{
    private IEMSDbContext _context;
    private StudentRepository _repository;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<IEMSDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new IEMSDbContext(options);
        _repository = new StudentRepository(_context);

        SeedTestData();
    }

    [TestMethod]
    public async Task GetPagedAsync_WithSearchTerm_ReturnsFilteredResults()
    {
        // Arrange
        var searchTerm = "John";

        // Act
        var result = await _repository.GetPagedAsync(1, 10, searchTerm);

        // Assert
        Assert.IsTrue(result.Items.All(s => s.Name.Contains(searchTerm)));
        Assert.IsTrue(result.TotalCount > 0);
    }

    [TestMethod]
    public async Task GetStudentsWithPendingFeesAsync_ReturnsOnlyStudentsWithPendingFees()
    {
        // Act
        var result = await _repository.GetStudentsWithPendingFeesAsync();

        // Assert
        Assert.IsTrue(result.All(s => s.TotalFees > s.PaidFees));
    }

    private void SeedTestData()
    {
        var students = new[]
        {
            new Student { Name = "John Doe", ClassName = "Class 1", ParentPhone = "1234567890", Address = "Address 1", TotalFees = 1000, PaidFees = 500 },
            new Student { Name = "Jane Smith", ClassName = "Class 2", ParentPhone = "0987654321", Address = "Address 2", TotalFees = 1200, PaidFees = 1200 },
            new Student { Name = "John Smith", ClassName = "Class 1", ParentPhone = "1122334455", Address = "Address 3", TotalFees = 1500, PaidFees = 800 }
        };

        _context.Students.AddRange(students);
        _context.SaveChanges();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }
}
```

#### 11.1.2 Service Testing
```csharp
[TestClass]
public class AuthenticationServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private AuthenticationService _authService;

    [TestInitialize]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _authService = new AuthenticationService(_userRepositoryMock.Object);
    }

    [TestMethod]
    public async Task AuthenticateAsync_WithValidCredentials_ReturnsSuccess()
    {
        // Arrange
        var username = "testuser";
        var password = "testpass";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            Username = username,
            PasswordHash = hashedPassword,
            IsActive = true,
            FailedLoginAttempts = 0
        };

        _userRepositoryMock.Setup(r => r.GetByUsernameAsync(username))
            .ReturnsAsync(user);

        // Act
        var result = await _authService.AuthenticateAsync(username, password);

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(user, result.User);
    }

    [TestMethod]
    public async Task AuthenticateAsync_WithInvalidPassword_ReturnsFailure()
    {
        // Arrange
        var username = "testuser";
        var password = "wrongpass";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword("correctpass");

        var user = new User
        {
            Username = username,
            PasswordHash = hashedPassword,
            IsActive = true,
            FailedLoginAttempts = 0
        };

        _userRepositoryMock.Setup(r => r.GetByUsernameAsync(username))
            .ReturnsAsync(user);

        // Act
        var result = await _authService.AuthenticateAsync(username, password);

        // Assert
        Assert.IsFalse(result.Success);
        Assert.IsNull(result.User);
    }
}
```

### 11.2 Integration Testing

#### 11.2.1 Database Integration Tests
```csharp
[TestClass]
public class DatabaseIntegrationTests
{
    private IEMSDbContext _context;

    [TestInitialize]
    public void Setup()
    {
        var connectionString = "Data Source=:memory:";
        var options = new DbContextOptionsBuilder<IEMSDbContext>()
            .UseSqlite(connectionString)
            .Options;

        _context = new IEMSDbContext(options);
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();
    }

    [TestMethod]
    public async Task CanCreateAndRetrieveStudent()
    {
        // Arrange
        var student = new Student
        {
            Name = "Test Student",
            ClassName = "Class 1",
            ParentPhone = "1234567890",
            Address = "Test Address",
            TotalFees = 1000,
            PaidFees = 500
        };

        // Act
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        var retrievedStudent = await _context.Students.FindAsync(student.Id);

        // Assert
        Assert.IsNotNull(retrievedStudent);
        Assert.AreEqual(student.Name, retrievedStudent.Name);
        Assert.AreEqual(student.ClassName, retrievedStudent.ClassName);
        Assert.AreEqual(500, retrievedStudent.PendingFees);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Database.CloseConnection();
        _context.Dispose();
    }
}
```

### 11.3 UI Testing

#### 11.3.1 ViewModel Testing
```csharp
[TestClass]
public class StudentListViewModelTests
{
    private Mock<IStudentService> _studentServiceMock;
    private Mock<INavigationService> _navigationServiceMock;
    private StudentListViewModel _viewModel;

    [TestInitialize]
    public void Setup()
    {
        _studentServiceMock = new Mock<IStudentService>();
        _navigationServiceMock = new Mock<INavigationService>();
        _viewModel = new StudentListViewModel(_studentServiceMock.Object, _navigationServiceMock.Object);
    }

    [TestMethod]
    public async Task LoadStudentsCommand_SetsStudentsProperty()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student { Name = "Student 1", ClassName = "Class 1" },
            new Student { Name = "Student 2", ClassName = "Class 2" }
        };

        var pagedResult = new PagedResult<Student>
        {
            Items = students,
            TotalCount = 2,
            Page = 1,
            PageSize = 10,
            TotalPages = 1
        };

        _studentServiceMock.Setup(s => s.GetPagedAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool?>()))
            .ReturnsAsync(pagedResult);

        // Act
        await _viewModel.LoadStudentsCommand.ExecuteAsync(null);

        // Assert
        Assert.AreEqual(2, _viewModel.Students.Count);
        Assert.AreEqual("Student 1", _viewModel.Students[0].Name);
    }
}
```

---

## 12. Deployment & Distribution

### 12.1 Installation Package

#### 12.1.1 MSI Installer Configuration
```xml
<?xml version="1.0" encoding="UTF-8"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Product Id="*"
           Name="IEMS School Management System"
           Language="1033"
           Version="1.0.0.0"
           Manufacturer="IEMS Solutions"
           UpgradeCode="12345678-1234-5678-9012-123456789012">

    <Package InstallerVersion="200" Compressed="yes" InstallScope="perMachine" />

    <MajorUpgrade DowngradeErrorMessage="A newer version is already installed." />

    <MediaTemplate EmbedCab="yes" />

    <Feature Id="ProductFeature" Title="IEMS School Management System" Level="1">
      <ComponentGroupRef Id="ProductComponents" />
    </Feature>

    <!-- Directory structure -->
    <Directory Id="TARGETDIR" Name="SourceDir">
      <Directory Id="ProgramFilesFolder">
        <Directory Id="ManufacturerFolder" Name="IEMS Solutions">
          <Directory Id="INSTALLFOLDER" Name="IEMS School Management System" />
        </Directory>
      </Directory>
      <Directory Id="ProgramMenuFolder">
        <Directory Id="ApplicationProgramsFolder" Name="IEMS School Management System"/>
      </Directory>
      <Directory Id="DesktopFolder" Name="Desktop" />
    </Directory>

    <!-- Components -->
    <ComponentGroup Id="ProductComponents" Directory="INSTALLFOLDER">
      <!-- Main application files -->
      <Component Id="MainExecutable">
        <File Id="MainExe" Source="$(var.PublishDir)\IEMS.WPF.exe" />
      </Component>

      <!-- Dependencies -->
      <Component Id="Dependencies">
        <File Source="$(var.PublishDir)\IEMS.Core.dll" />
        <File Source="$(var.PublishDir)\IEMS.Infrastructure.dll" />
        <File Source="$(var.PublishDir)\IEMS.Application.dll" />
        <!-- Add all other dependencies -->
      </Component>

      <!-- Desktop shortcut -->
      <Component Id="DesktopShortcut" Directory="DesktopFolder">
        <Shortcut Id="DesktopShortcut"
                  Name="IEMS School Management"
                  Target="[INSTALLFOLDER]IEMS.WPF.exe"
                  WorkingDirectory="INSTALLFOLDER"/>
        <RemoveFolder Id="DesktopFolder" On="uninstall"/>
        <RegistryValue Root="HKCU" Key="Software\IEMS\Desktop" Type="string" Value="" KeyPath="yes"/>
      </Component>

      <!-- Start menu shortcut -->
      <Component Id="StartMenuShortcut" Directory="ApplicationProgramsFolder">
        <Shortcut Id="StartMenuShortcut"
                  Name="IEMS School Management"
                  Target="[INSTALLFOLDER]IEMS.WPF.exe"
                  WorkingDirectory="INSTALLFOLDER"/>
        <RemoveFolder Id="ApplicationProgramsFolder" On="uninstall"/>
        <RegistryValue Root="HKCU" Key="Software\IEMS\StartMenu" Type="string" Value="" KeyPath="yes"/>
      </Component>
    </ComponentGroup>

    <!-- Custom actions for .NET runtime check -->
    <CustomAction Id="CheckDotNetRuntime"
                  BinaryKey="CustomActionDLL"
                  DllEntry="CheckDotNetRuntime"
                  Execute="immediate" />

    <InstallExecuteSequence>
      <Custom Action="CheckDotNetRuntime" Before="LaunchConditions" />
    </InstallExecuteSequence>

  </Product>
</Wix>
```

#### 12.1.2 Installation Requirements Check
```csharp
public class InstallationChecker
{
    public static bool CheckSystemRequirements()
    {
        var results = new List<bool>
        {
            CheckOperatingSystem(),
            CheckDotNetRuntime(),
            CheckAvailableSpace(),
            CheckMemory()
        };

        return results.All(r => r);
    }

    private static bool CheckOperatingSystem()
    {
        var version = Environment.OSVersion.Version;

        // Windows 10 version 1903 (Build 18362) or later
        return version.Major >= 10 && version.Build >= 18362;
    }

    private static bool CheckDotNetRuntime()
    {
        try
        {
            var runtimeVersion = RuntimeInformation.FrameworkDescription;
            // Check for .NET 8.0 or later
            return runtimeVersion.Contains(".NET 8") || runtimeVersion.Contains(".NET 9");
        }
        catch
        {
            return false;
        }
    }

    private static bool CheckAvailableSpace()
    {
        var drives = DriveInfo.GetDrives();
        var systemDrive = drives.FirstOrDefault(d => d.Name.StartsWith("C:"));

        if (systemDrive != null)
        {
            var availableSpaceGB = systemDrive.AvailableFreeSpace / (1024 * 1024 * 1024);
            return availableSpaceGB >= 2; // Minimum 2 GB
        }

        return false;
    }

    private static bool CheckMemory()
    {
        // Check for minimum 4 GB RAM
        var memoryInfo = GC.GetTotalMemory(false);
        var totalMemoryGB = new PerformanceCounter("Memory", "Available MBytes").RawValue / 1024;

        return totalMemoryGB >= 3; // Allow some margin for OS
    }
}
```

### 12.2 Application Updates

#### 12.2.1 Update System
```csharp
public class UpdateManager
{
    private readonly string _updateCheckUrl = "https://updates.iems.edu/api/version";
    private readonly string _currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public async Task<UpdateInfo> CheckForUpdatesAsync()
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(_updateCheckUrl);
                var updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(response);

                if (IsNewerVersion(updateInfo.Version, _currentVersion))
                {
                    updateInfo.IsUpdateAvailable = true;
                }

                return updateInfo;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to check for updates");
            return new UpdateInfo { IsUpdateAvailable = false, Error = ex.Message };
        }
    }

    public async Task<bool> DownloadAndInstallUpdateAsync(UpdateInfo updateInfo, IProgress<int> progress)
    {
        try
        {
            var updateFilePath = Path.Combine(Path.GetTempPath(), "IEMS_Update.msi");

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(updateInfo.DownloadUrl, HttpCompletionOption.ResponseHeadersRead);
                var totalBytes = response.Content.Headers.ContentLength ?? 0;

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = File.Create(updateFilePath))
                {
                    var buffer = new byte[8192];
                    var totalRead = 0L;
                    int bytesRead;

                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        totalRead += bytesRead;

                        if (totalBytes > 0)
                        {
                            var percentage = (int)((totalRead * 100) / totalBytes);
                            progress?.Report(percentage);
                        }
                    }
                }
            }

            // Launch installer
            var processInfo = new ProcessStartInfo
            {
                FileName = "msiexec",
                Arguments = $"/i \"{updateFilePath}\" /quiet",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process.Start(processInfo);

            // Exit current application
            Application.Current.Shutdown();

            return true;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to download and install update");
            return false;
        }
    }

    private bool IsNewerVersion(string remoteVersion, string currentVersion)
    {
        var remote = Version.Parse(remoteVersion);
        var current = Version.Parse(currentVersion);

        return remote > current;
    }
}

public class UpdateInfo
{
    public string Version { get; set; }
    public string DownloadUrl { get; set; }
    public string ReleaseNotes { get; set; }
    public bool IsUpdateAvailable { get; set; }
    public string Error { get; set; }
}
```

### 12.3 Configuration Management

#### 12.3.1 Application Configuration
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="appSettings" type="System.Configuration.AppSettingsSection, System.Configuration" />
    <section name="connectionStrings" type="System.Configuration.ConnectionStringsSection, System.Configuration" />
  </configSections>

  <appSettings>
    <!-- Database Configuration -->
    <add key="DatabasePath" value="%APPDATA%\IEMS\Database\iems_school.db" />
    <add key="DatabaseBackupPath" value="%APPDATA%\IEMS\Backups" />

    <!-- Application Settings -->
    <add key="DefaultLanguage" value="en" />
    <add key="SessionTimeoutMinutes" value="60" />
    <add key="MaxLoginAttempts" value="5" />
    <add key="AccountLockoutMinutes" value="15" />

    <!-- UI Settings -->
    <add key="DefaultPageSize" value="50" />
    <add key="MaxPageSize" value="500" />
    <add key="AutoSaveInterval" value="300" />

    <!-- PDF Settings -->
    <add key="SchoolName" value="Inspire English Medium School" />
    <add key="SchoolAddress" value="Adharwadi Kalyan, Thane - 421301" />
    <add key="SchoolPhone" value="+91 9876543210" />
    <add key="SchoolEmail" value="info@iems.edu" />

    <!-- Update Settings -->
    <add key="CheckForUpdates" value="true" />
    <add key="UpdateCheckInterval" value="24" />
    <add key="UpdateUrl" value="https://updates.iems.edu" />
  </appSettings>

  <connectionStrings>
    <add name="DefaultConnection"
         connectionString="Data Source=%APPDATA%\IEMS\Database\iems_school.db;Cache=Shared;Pooling=true"
         providerName="Microsoft.Data.Sqlite" />
  </connectionStrings>

  <system.windows.forms>
    <applicationSettings>
      <IEMS.WPF.Properties.Settings>
        <setting name="WindowState" serializeAs="String">
          <value>Normal</value>
        </setting>
        <setting name="WindowSize" serializeAs="String">
          <value>1200,800</value>
        </setting>
        <setting name="WindowLocation" serializeAs="String">
          <value>100,100</value>
        </setting>
      </IEMS.WPF.Properties.Settings>
    </applicationSettings>
  </system.windows.forms>
</configuration>
```

#### 12.3.2 School-Specific Configuration
```csharp
public class SchoolConfiguration
{
    public string SchoolName { get; set; } = "Inspire English Medium School";
    public string SchoolAddress { get; set; } = "Adharwadi Kalyan, Thane - 421301";
    public string SchoolPhone { get; set; } = "+91 9876543210";
    public string SchoolEmail { get; set; } = "info@iems.edu";
    public string SchoolWebsite { get; set; } = "www.iems.edu";
    public string PrincipalName { get; set; } = "Dr. Principal Name";
    public string AcademicYear { get; set; } = "2024-25";
    public byte[] SchoolLogo { get; set; }

    public static SchoolConfiguration Load()
    {
        var configPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "IEMS",
            "school_config.json"
        );

        if (File.Exists(configPath))
        {
            var json = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<SchoolConfiguration>(json);
        }

        return new SchoolConfiguration();
    }

    public void Save()
    {
        var configPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "IEMS",
            "school_config.json"
        );

        Directory.CreateDirectory(Path.GetDirectoryName(configPath));

        var json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(configPath, json);
    }
}
```

---

## Conclusion

This comprehensive requirements document provides a complete blueprint for developing the IEMS School Management System for Windows 10. The document covers all aspects from technical architecture to deployment strategies, ensuring that the Windows application will maintain full feature parity with the existing Android application while leveraging the advantages of the desktop platform.

**Key Implementation Priorities:**

1. **Phase 1**: Core infrastructure (database, authentication, basic MVVM setup)
2. **Phase 2**: Student management and fee collection modules
3. **Phase 3**: Employee management and payroll system
4. **Phase 4**: Transport and expense management
5. **Phase 5**: Reports, analytics, and advanced features
6. **Phase 6**: Testing, optimization, and deployment

**Success Metrics:**

- 100% feature parity with Android application
- Sub-2 second response times for common operations
- Support for 10,000+ students without performance degradation
- Successful deployment and user adoption
- Zero data loss during migration from Android application

This document serves as the foundation for successful Windows application development, ensuring a professional, reliable, and user-friendly school management system that meets the specific needs of IEMS and similar educational institutions.

---

**Document Information:**
- **Version**: 1.0
- **Last Updated**: September 16, 2025
- **Next Review**: December 16, 2025
- **Status**: Ready for Development