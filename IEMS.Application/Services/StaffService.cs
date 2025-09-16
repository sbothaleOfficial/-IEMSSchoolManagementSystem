using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;

namespace IEMS.Application.Services;

public class StaffService
{
    private readonly IStaffRepository _staffRepository;

    public StaffService(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<IEnumerable<StaffDto>> GetAllStaffAsync()
    {
        var staff = await _staffRepository.GetAllAsync();
        return staff.Select(MapToDto);
    }

    public async Task<StaffDto?> GetStaffByIdAsync(int id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);
        return staff != null ? MapToDto(staff) : null;
    }

    public async Task<StaffDto?> GetStaffByEmployeeIdAsync(string employeeId)
    {
        var staff = await _staffRepository.GetStaffByEmployeeIdAsync(employeeId);
        return staff != null ? MapToDto(staff) : null;
    }

    public async Task<IEnumerable<StaffDto>> GetStaffByDepartmentAsync(string department)
    {
        var staff = await _staffRepository.GetStaffByDepartmentAsync(department);
        return staff.Select(MapToDto);
    }

    public async Task<IEnumerable<StaffDto>> GetStaffByPositionAsync(string position)
    {
        var staff = await _staffRepository.GetStaffByPositionAsync(position);
        return staff.Select(MapToDto);
    }

    public async Task<StaffDto> CreateStaffAsync(StaffDto staffDto)
    {
        // Check if employee ID already exists
        var existingStaff = await _staffRepository.GetStaffByEmployeeIdAsync(staffDto.EmployeeId);

        if (existingStaff != null)
        {
            throw new ArgumentException($"Employee ID '{staffDto.EmployeeId}' already exists.");
        }

        var staff = new Staff
        {
            EmployeeId = staffDto.EmployeeId,
            FirstName = staffDto.FirstName,
            LastName = staffDto.LastName,
            Email = staffDto.Email,
            PhoneNumber = staffDto.PhoneNumber,
            DateOfBirth = staffDto.DateOfBirth,
            Gender = staffDto.Gender,
            Address = staffDto.Address,
            Position = staffDto.Position,
            Department = staffDto.Department,
            HireDate = staffDto.HireDate,
            Salary = staffDto.Salary,
            Status = staffDto.Status,
            EmergencyContact = staffDto.EmergencyContact,
            EmergencyContactPhone = staffDto.EmergencyContactPhone,
            Qualifications = staffDto.Qualifications,
            Experience = staffDto.Experience,
            Remarks = staffDto.Remarks,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _staffRepository.AddAsync(staff);
        return MapToDto(staff);
    }

    public async Task<StaffDto> UpdateStaffAsync(StaffDto staffDto)
    {
        var staff = await _staffRepository.GetByIdAsync(staffDto.Id);
        if (staff == null)
        {
            throw new ArgumentException($"Staff member with ID {staffDto.Id} not found.");
        }

        // Check if employee ID already exists for a different staff member
        var existingStaff = await _staffRepository.GetStaffByEmployeeIdAsync(staffDto.EmployeeId);
        if (existingStaff != null && existingStaff.Id != staffDto.Id)
        {
            throw new ArgumentException($"Employee ID '{staffDto.EmployeeId}' already exists.");
        }

        staff.EmployeeId = staffDto.EmployeeId;
        staff.FirstName = staffDto.FirstName;
        staff.LastName = staffDto.LastName;
        staff.Email = staffDto.Email;
        staff.PhoneNumber = staffDto.PhoneNumber;
        staff.DateOfBirth = staffDto.DateOfBirth;
        staff.Gender = staffDto.Gender;
        staff.Address = staffDto.Address;
        staff.Position = staffDto.Position;
        staff.Department = staffDto.Department;
        staff.HireDate = staffDto.HireDate;
        staff.Salary = staffDto.Salary;
        staff.Status = staffDto.Status;
        staff.EmergencyContact = staffDto.EmergencyContact;
        staff.EmergencyContactPhone = staffDto.EmergencyContactPhone;
        staff.Qualifications = staffDto.Qualifications;
        staff.Experience = staffDto.Experience;
        staff.Remarks = staffDto.Remarks;
        staff.UpdatedAt = DateTime.Now;

        await _staffRepository.UpdateAsync(staff);
        return MapToDto(staff);
    }

    public async Task DeleteStaffAsync(int id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);
        if (staff == null)
        {
            throw new ArgumentException($"Staff member with ID {id} not found.");
        }

        await _staffRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<string>> GetDepartmentsAsync()
    {
        return await _staffRepository.GetDepartmentsAsync();
    }

    public async Task<IEnumerable<string>> GetPositionsAsync()
    {
        return await _staffRepository.GetPositionsAsync();
    }

    public async Task<int> GetTotalStaffCountAsync()
    {
        var allStaff = await _staffRepository.GetAllAsync();
        return allStaff.Count();
    }

    public async Task<int> GetActiveStaffCountAsync()
    {
        return await _staffRepository.GetActiveStaffCountAsync();
    }

    private static StaffDto MapToDto(Staff staff)
    {
        return new StaffDto
        {
            Id = staff.Id,
            EmployeeId = staff.EmployeeId,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            PhoneNumber = staff.PhoneNumber,
            DateOfBirth = staff.DateOfBirth,
            Gender = staff.Gender,
            Address = staff.Address,
            Position = staff.Position,
            Department = staff.Department,
            HireDate = staff.HireDate,
            Salary = staff.Salary,
            Status = staff.Status,
            EmergencyContact = staff.EmergencyContact,
            EmergencyContactPhone = staff.EmergencyContactPhone,
            Qualifications = staff.Qualifications,
            Experience = staff.Experience,
            Remarks = staff.Remarks,
            CreatedAt = staff.CreatedAt,
            UpdatedAt = staff.UpdatedAt
        };
    }
}