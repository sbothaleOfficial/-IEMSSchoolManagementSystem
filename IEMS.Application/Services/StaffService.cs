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
            PhoneNumber = staffDto.PhoneNumber,
            DateOfBirth = staffDto.DateOfBirth,
            Gender = staffDto.Gender,
            Address = staffDto.Address,
            Position = staffDto.Position,
            Salary = staffDto.Salary,
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
        staff.PhoneNumber = staffDto.PhoneNumber;
        staff.DateOfBirth = staffDto.DateOfBirth;
        staff.Gender = staffDto.Gender;
        staff.Address = staffDto.Address;
        staff.Position = staffDto.Position;
        staff.Salary = staffDto.Salary;
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


    public async Task<IEnumerable<string>> GetPositionsAsync()
    {
        return await _staffRepository.GetPositionsAsync();
    }

    public async Task<int> GetTotalStaffCountAsync()
    {
        var allStaff = await _staffRepository.GetAllAsync();
        return allStaff.Count();
    }


    private static StaffDto MapToDto(Staff staff)
    {
        return new StaffDto
        {
            Id = staff.Id,
            EmployeeId = staff.EmployeeId,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            PhoneNumber = staff.PhoneNumber,
            DateOfBirth = staff.DateOfBirth,
            Gender = staff.Gender,
            Address = staff.Address,
            Position = staff.Position,
            Salary = staff.Salary,
            CreatedAt = staff.CreatedAt,
            UpdatedAt = staff.UpdatedAt
        };
    }
}