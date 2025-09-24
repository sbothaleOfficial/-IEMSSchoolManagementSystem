# IEMS School Management System - Complete Database Schema Documentation

## Database Overview
- **Database Type**: SQLite
- **ORM**: Entity Framework Core 8.0
- **Architecture**: Code-First approach
- **Total Tables**: 11 core tables
- **Primary Database File**: `school.db`

## Schema Evolution History

### Migration Timeline:
1. **20250918113435_AddCityVillageToStudent**: Initial schema creation with all core tables
2. **20250918121812_AddMissingStaffColumns**: Added missing Staff entity columns
3. **20250918145454_FixTeacherMonthlySalaryDataType**: Fixed Teacher salary data type
4. **20250919125020_AddExpenseManagementEntities**: Added expense management entities
5. **20250919151944_AddExpenseManagementTables**: Final expense table adjustments

---

## Complete Table Documentation

### 1. **AcademicYears** Table
**Purpose**: Manages academic year periods and current year tracking

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| Year | TEXT | 10 | No | Yes | - | Academic year format (e.g., "2024-25") |
| StartDate | TEXT | - | No | No | - | Academic year start date |
| EndDate | TEXT | - | No | No | - | Academic year end date |
| IsCurrent | INTEGER (bool) | - | No | No | false | Indicates current active academic year |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_AcademicYears_Year` (Unique)

**Seed Data**: Academic years 2023-24, 2024-25 (current), 2025-26

---

### 2. **Teachers** Table
**Purpose**: Stores teacher/faculty information and employment details

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| EmployeeId | TEXT | 20 | No | Yes | - | Unique employee identifier |
| FirstName | TEXT | 50 | No | No | - | Teacher's first name |
| LastName | TEXT | 50 | No | No | - | Teacher's last name |
| PhoneNumber | TEXT | - | No | No | - | Contact phone number |
| Address | TEXT | - | No | No | - | Residential address |
| JoiningDate | TEXT | - | No | No | - | Employment start date |
| MonthlySalary | decimal(18,2) | - | No | No | - | Monthly salary amount |
| Email | TEXT | - | Yes | No | null | Email address (optional) |
| BankAccountNumber | TEXT | - | Yes | No | null | Bank account for salary (optional) |
| AadharNumber | TEXT | - | Yes | No | null | Aadhar card number (optional) |
| PANNumber | TEXT | - | Yes | No | null | PAN card number (optional) |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_Teachers_EmployeeId` (Unique)

**Relationships**:
- One-to-Many with Classes (TeacherId)

**Seed Data**: 5 teachers with complete employment details

---

### 3. **Staff** Table
**Purpose**: Stores non-teaching staff information (drivers, clerks, peons, etc.)

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| EmployeeId | TEXT | 20 | No | Yes | - | Unique employee identifier |
| FirstName | TEXT | 50 | No | No | - | Staff member's first name |
| LastName | TEXT | 50 | No | No | - | Staff member's last name |
| PhoneNumber | TEXT | 15 | No | No | - | Contact phone number |
| Address | TEXT | 200 | No | No | - | Residential address |
| JoiningDate | TEXT | - | No | No | - | Employment start date |
| MonthlySalary | decimal(18,2) | - | No | No | - | Monthly salary amount |
| Position | TEXT | 50 | No | No | - | Staff position/role |
| Email | TEXT | 100 | Yes | No | null | Email address (optional) |
| BankAccountNumber | TEXT | 20 | Yes | No | null | Bank account for salary (optional) |
| AadharNumber | TEXT | 12 | Yes | No | null | Aadhar card number (optional) |
| PANNumber | TEXT | 10 | Yes | No | null | PAN card number (optional) |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_Staff_EmployeeId` (Unique)

**Seed Data**: 3 staff members (Driver, Peon, Clerk)

---

### 4. **Classes** Table
**Purpose**: Represents academic classes with teacher assignments

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| Name | TEXT | 50 | No | No | - | Class name (e.g., "Grade 10") |
| Section | TEXT | 10 | No | No | - | Class section (e.g., "A", "B") |
| TeacherId | INTEGER | - | No | FK | - | Assigned teacher reference |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_Classes_TeacherId`

**Foreign Keys**:
- `FK_Classes_Teachers_TeacherId` (Restrict on delete)

**Relationships**:
- Many-to-One with Teachers
- One-to-Many with Students
- One-to-Many with FeeStructures

**Seed Data**: 10 classes across Grades 8-10 with sections A-C

---

### 5. **Students** Table
**Purpose**: Core student information and academic details

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| SerialNo | INTEGER | - | No | Yes | - | Unique serial number |
| Standard | TEXT | 20 | No | No | - | Academic standard/grade |
| ClassDivision | TEXT | 10 | No | No | - | Class section identifier |
| FirstName | TEXT | 50 | No | No | - | Student's first name |
| FatherName | TEXT | 50 | No | No | - | Father's name |
| Surname | TEXT | 50 | No | No | - | Student's surname |
| DateOfBirth | TEXT | - | No | No | - | Birth date |
| Gender | TEXT | 10 | No | No | - | Gender (Male/Female) |
| MotherName | TEXT | 50 | No | No | - | Mother's name |
| StudentNumber | TEXT | 20 | No | Yes | - | Unique student identifier |
| AdmissionDate | TEXT | - | No | No | - | School admission date |
| CasteCategory | TEXT | 30 | No | No | - | Caste category |
| Religion | TEXT | 30 | No | No | - | Religious affiliation |
| IsBPL | INTEGER (bool) | - | No | No | false | Below Poverty Line status |
| IsSemiEnglish | INTEGER (bool) | - | No | No | false | Semi-English medium indicator |
| Address | TEXT | 200 | No | No | - | Residential address |
| CityVillage | TEXT | 100 | No | No | - | City or village |
| ParentMobileNumber | TEXT | 15 | No | No | - | Parent contact number |
| ClassId | INTEGER | - | No | FK | - | Assigned class reference |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_Students_SerialNo` (Unique)
- `IX_Students_StudentNumber` (Unique)
- `IX_Students_ClassId`

**Foreign Keys**:
- `FK_Students_Classes_ClassId` (Restrict on delete)

**Relationships**:
- Many-to-One with Classes
- One-to-Many with FeePayments

**Seed Data**: 120+ students across multiple classes with diverse demographic data

---

### 6. **FeeStructures** Table
**Purpose**: Defines fee amounts by class and fee type

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| ClassId | INTEGER | - | No | FK | - | Associated class reference |
| FeeType | INTEGER (enum) | - | No | No | - | Type of fee (see FeeType enum) |
| Amount | decimal(18,2) | - | No | No | - | Fee amount |
| AcademicYear | TEXT | 10 | No | No | - | Academic year for fee |
| Description | TEXT | 200 | No | No | - | Fee description |
| IsActive | INTEGER (bool) | - | No | No | true | Fee structure active status |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_FeeStructures_ClassId_FeeType_AcademicYear` (Unique composite)

**Foreign Keys**:
- `FK_FeeStructures_Classes_ClassId` (Restrict on delete)

**Relationships**:
- Many-to-One with Classes

**Seed Data**: Fee structures for all classes including Tuition, Admission, Exam, Transport fees

---

### 7. **FeePayments** Table
**Purpose**: Records all fee payment transactions

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| ReceiptNumber | TEXT | 20 | No | Yes | - | Unique receipt identifier |
| StudentId | INTEGER | - | No | FK | - | Student making payment |
| FeeType | INTEGER (enum) | - | No | No | - | Type of fee being paid |
| AmountPaid | decimal(18,2) | - | No | No | - | Amount paid |
| PaymentMethod | INTEGER (enum) | - | No | No | - | Payment method used |
| TransactionId | TEXT | 100 | Yes | No | null | Online transaction ID |
| ChequeNumber | TEXT | 50 | Yes | No | null | Cheque number if applicable |
| BankName | TEXT | 100 | Yes | No | null | Bank name for cheque/DD |
| PaymentNotes | TEXT | 500 | Yes | No | null | Additional payment notes |
| PreviousBalance | decimal(18,2) | - | No | No | 0 | Balance before payment |
| RemainingBalance | decimal(18,2) | - | No | No | 0 | Balance after payment |
| LateFee | decimal(18,2) | - | No | No | 0 | Late fee charged |
| Discount | decimal(18,2) | - | No | No | 0 | Discount applied |
| InstallmentNumber | INTEGER | - | Yes | No | null | Installment sequence |
| NextDueDate | TEXT | - | Yes | No | null | Next payment due date |
| AcademicYear | TEXT | 10 | No | No | - | Academic year |
| GeneratedBy | TEXT | 100 | No | No | - | User who generated receipt |
| PaymentDate | TEXT | - | No | No | - | Date of payment |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_FeePayments_ReceiptNumber` (Unique)
- `IX_FeePayments_StudentId`

**Foreign Keys**:
- `FK_FeePayments_Students_StudentId` (Restrict on delete)

**Relationships**:
- Many-to-One with Students

---

### 8. **Vehicles** Table
**Purpose**: Manages school transport vehicles

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| VehicleNumber | TEXT | 20 | No | Yes | - | Vehicle registration number |
| VehicleType | INTEGER (enum) | - | No | No | - | Type of vehicle (see VehicleType enum) |
| DriverName | TEXT | 100 | No | No | - | Assigned driver name |
| DriverPhone | TEXT | 15 | No | No | - | Driver contact number |
| Route | TEXT | 200 | No | No | - | Vehicle route description |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_Vehicles_VehicleNumber` (Unique)

**Relationships**:
- One-to-Many with TransportExpenses

**Seed Data**: 3 vehicles (Bus, Auto, Traveller) with route information

---

### 9. **TransportExpenses** Table
**Purpose**: Tracks vehicle-related expenses

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| VehicleId | INTEGER | - | No | FK | - | Associated vehicle reference |
| Category | INTEGER (enum) | - | No | No | - | Expense category (see ExpenseCategory enum) |
| FuelType | INTEGER (enum) | - | Yes | No | null | Fuel type if fuel expense |
| Amount | decimal(18,2) | - | No | No | - | Expense amount |
| Quantity | decimal(18,2) | - | No | No | - | Quantity (liters for fuel, etc.) |
| ExpenseDate | TEXT | - | No | No | - | Date of expense |
| DriverName | TEXT | 100 | No | No | - | Driver responsible |
| Description | TEXT | 500 | No | No | - | Expense description |
| InvoiceNumber | TEXT | 50 | No | No | - | Invoice/bill number |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_TransportExpenses_VehicleId`

**Foreign Keys**:
- `FK_TransportExpenses_Vehicles_VehicleId` (Restrict on delete)

**Relationships**:
- Many-to-One with Vehicles

**Seed Data**: Sample fuel and maintenance expenses

---

### 10. **ElectricityBills** Table
**Purpose**: Manages electricity utility bills

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| BillNumber | TEXT | 20 | No | Yes | - | Utility bill number |
| BillMonth | INTEGER | - | No | No | - | Bill month (1-12) |
| BillYear | INTEGER | - | No | No | - | Bill year |
| Amount | decimal(18,2) | - | No | No | - | Bill amount |
| Units | decimal(18,2) | - | No | No | - | Electricity units consumed |
| IsPaid | INTEGER (bool) | - | No | No | false | Payment status |
| PaidDate | TEXT | - | Yes | No | null | Payment date if paid |
| DueDate | TEXT | - | No | No | - | Bill due date |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Indexes**:
- `IX_ElectricityBills_BillNumber` (Unique)
- `IX_ElectricityBills_BillMonth_BillYear` (Unique composite)

**Seed Data**: 3 months of electricity bills

---

### 11. **OtherExpenses** Table
**Purpose**: Tracks miscellaneous school expenses

| Column | Data Type | Max Length | Nullable | Unique | Default | Description |
|--------|-----------|------------|----------|---------|---------|-------------|
| Id | INTEGER | - | No | PK | Auto-increment | Primary key |
| Category | INTEGER (enum) | - | No | No | - | Expense category (see OtherExpenseCategory enum) |
| ExpenseType | TEXT | 100 | No | No | - | Specific expense type |
| Description | TEXT | 500 | No | No | - | Detailed description |
| Amount | decimal(18,2) | - | No | No | - | Expense amount |
| PaymentMethod | INTEGER (enum) | - | No | No | - | Payment method used |
| ExpenseDate | TEXT | - | No | No | - | Date of expense |
| InvoiceNumber | TEXT | 50 | Yes | No | null | Invoice number if available |
| Vendor | TEXT | 100 | Yes | No | null | Vendor/supplier name |
| CreatedAt | TEXT | - | No | No | UtcNow | Record creation timestamp |
| UpdatedAt | TEXT | - | No | No | UtcNow | Last update timestamp |

**Seed Data**: Sample stationery, event, and maintenance expenses

---

## Enumerated Data Types

### FeeType Enum
- `TUITION = 0`: Tuition fees
- `ADMISSION = 1`: Admission fees
- `EXAM = 2`: Examination fees
- `TRANSPORT = 3`: Transportation fees
- `SPORTS = 4`: Sports fees
- `LIBRARY = 5`: Library fees
- `UNIFORM = 6`: Uniform fees
- `MISCELLANEOUS = 7`: Other fees

### PaymentMethod Enum
- `CASH = 0`: Cash payment
- `ONLINE = 1`: Online payment
- `CHEQUE = 2`: Cheque payment
- `DD = 3`: Demand Draft payment

### VehicleType Enum
- `BUS = 1`: School bus
- `AUTO = 2`: Auto-rickshaw
- `TRAVELLER = 3`: Traveller vehicle
- `BIKE = 4`: Motorcycle

### ExpenseCategory Enum
- `FUEL = 1`: Fuel expenses
- `MAINTENANCE = 2`: Vehicle maintenance
- `INSURANCE = 3`: Insurance payments
- `SERVICE = 4`: Service charges
- `REPAIR = 5`: Repair costs
- `PERMIT = 6`: Permit fees
- `TAX = 7`: Tax payments
- `OTHER = 8`: Other expenses

### FuelType Enum
- `DIESEL = 1`: Diesel fuel
- `PETROL = 2`: Petrol fuel
- `CNG = 3`: CNG fuel
- `ELECTRIC = 4`: Electric charging

### OtherExpenseCategory Enum
- `STATIONERY = 1`: Stationery supplies
- `EVENT = 2`: School events
- `MAINTENANCE = 3`: Building maintenance
- `SUPPLIES = 4`: General supplies
- `UTILITIES = 5`: Utility bills
- `CLEANING = 6`: Cleaning supplies
- `SECURITY = 7`: Security services
- `MISCELLANEOUS = 8`: Other expenses

---

## Database Relationships Summary

### Primary Relationships:
1. **Teachers** → **Classes** (1:M)
2. **Classes** → **Students** (1:M)
3. **Classes** → **FeeStructures** (1:M)
4. **Students** → **FeePayments** (1:M)
5. **Vehicles** → **TransportExpenses** (1:M)

### Key Business Rules:
- All foreign key relationships use `Restrict` delete behavior for data integrity
- Unique constraints prevent duplicate student numbers, employee IDs, vehicle numbers
- Composite unique constraints ensure fee structures don't duplicate for same class/type/year
- Decimal(18,2) precision for all monetary values
- DateTime fields stored as TEXT in SQLite format
- Comprehensive seed data provides realistic test scenarios

### Data Integrity Features:
- Unique indexes on critical business identifiers
- Composite unique constraints for business rule enforcement
- Non-nullable foreign keys maintain referential integrity
- Default timestamps for audit trail
- Enum-based data validation for consistent values

---

## Technical Implementation Details

### Entity Framework Configuration:
- Code-First approach with Fluent API configuration
- Comprehensive ModelBuilder configuration in `ApplicationDbContext`
- Proper entity state change tracking with `UpdatedAt` timestamps
- Seed data methodology using `HasData()` for all entities

### Migration Strategy:
- Incremental schema evolution through EF Core migrations
- Backward compatible changes with proper rollback support
- Comprehensive seed data updates with each migration
- Production-ready migration scripts with timestamp management

### Performance Considerations:
- Strategic indexing on frequently queried columns
- Composite indexes for complex query optimization
- Foreign key indexes for join operation efficiency
- Unique constraint indexes for data validation

This comprehensive schema supports a full-featured school management system with strong data integrity, audit capabilities, and scalable architecture.