using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;

namespace IEMS.Application.Services;

public class AcademicYearService
{
    private readonly IAcademicYearRepository _academicYearRepository;

    public AcademicYearService(IAcademicYearRepository academicYearRepository)
    {
        _academicYearRepository = academicYearRepository;
    }

    public async Task<IEnumerable<AcademicYearDto>> GetAllAcademicYearsAsync()
    {
        var academicYears = await _academicYearRepository.GetAllAsync();
        return academicYears.Select(MapToDto).OrderByDescending(ay => ay.StartDate);
    }

    public async Task<AcademicYearDto?> GetAcademicYearByIdAsync(int id)
    {
        var academicYear = await _academicYearRepository.GetByIdAsync(id);
        return academicYear != null ? MapToDto(academicYear) : null;
    }

    public async Task<AcademicYearDto?> GetCurrentAcademicYearAsync()
    {
        var currentAcademicYear = await _academicYearRepository.GetCurrentAcademicYearAsync();
        return currentAcademicYear != null ? MapToDto(currentAcademicYear) : null;
    }

    public async Task<IEnumerable<AcademicYearDto>> GetRecentAcademicYearsAsync(int count = 5)
    {
        var recentYears = await _academicYearRepository.GetRecentAcademicYearsAsync(count);
        return recentYears.Select(MapToDto);
    }

    public async Task<AcademicYearDto> AddAcademicYearAsync(AcademicYearDto academicYearDto)
    {
        var academicYear = new AcademicYear
        {
            Year = academicYearDto.Year,
            StartDate = academicYearDto.StartDate,
            EndDate = academicYearDto.EndDate,
            IsCurrent = academicYearDto.IsCurrent
        };

        var addedAcademicYear = await _academicYearRepository.AddAsync(academicYear);
        return MapToDto(addedAcademicYear);
    }

    public async Task<AcademicYearDto> UpdateAcademicYearAsync(AcademicYearDto academicYearDto)
    {
        var existingAcademicYear = await _academicYearRepository.GetByIdAsync(academicYearDto.Id);
        if (existingAcademicYear == null)
        {
            throw new ArgumentException($"Academic year with ID {academicYearDto.Id} not found.");
        }

        existingAcademicYear.Year = academicYearDto.Year;
        existingAcademicYear.StartDate = academicYearDto.StartDate;
        existingAcademicYear.EndDate = academicYearDto.EndDate;
        existingAcademicYear.IsCurrent = academicYearDto.IsCurrent;

        await _academicYearRepository.UpdateAsync(existingAcademicYear);
        return MapToDto(existingAcademicYear);
    }

    public async Task DeleteAcademicYearAsync(int id)
    {
        await _academicYearRepository.DeleteAsync(id);
    }

    public async Task SetCurrentAcademicYearAsync(int academicYearId)
    {
        await _academicYearRepository.SetCurrentAcademicYearAsync(academicYearId);
    }

    private static AcademicYearDto MapToDto(AcademicYear academicYear)
    {
        return new AcademicYearDto
        {
            Id = academicYear.Id,
            Year = academicYear.Year,
            StartDate = academicYear.StartDate,
            EndDate = academicYear.EndDate,
            IsCurrent = academicYear.IsCurrent
        };
    }
}