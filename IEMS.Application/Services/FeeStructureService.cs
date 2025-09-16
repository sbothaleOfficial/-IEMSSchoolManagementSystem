using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;

namespace IEMS.Application.Services;

public class FeeStructureService
{
    private readonly IFeeStructureRepository _feeStructureRepository;
    private readonly IClassRepository _classRepository;

    public FeeStructureService(IFeeStructureRepository feeStructureRepository, IClassRepository classRepository)
    {
        _feeStructureRepository = feeStructureRepository;
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<FeeStructureDto>> GetAllFeeStructuresAsync()
    {
        var feeStructures = await _feeStructureRepository.GetAllAsync();
        return feeStructures.Select(MapToDto);
    }

    public async Task<FeeStructureDto?> GetFeeStructureByIdAsync(int id)
    {
        var feeStructure = await _feeStructureRepository.GetByIdAsync(id);
        return feeStructure != null ? MapToDto(feeStructure) : null;
    }

    public async Task<IEnumerable<FeeStructureDto>> GetFeeStructuresByClassIdAsync(int classId)
    {
        var feeStructures = await _feeStructureRepository.GetByClassIdAsync(classId);
        return feeStructures.Select(MapToDto);
    }

    public async Task<IEnumerable<FeeStructureDto>> GetFeeStructuresByAcademicYearAsync(string academicYear)
    {
        var feeStructures = await _feeStructureRepository.GetByAcademicYearAsync(academicYear);
        return feeStructures.Select(MapToDto);
    }

    public async Task<FeeStructureDto?> GetFeeStructureByClassFeeTypeAndYearAsync(int classId, FeeType feeType, string academicYear)
    {
        var feeStructure = await _feeStructureRepository.GetByClassIdFeeTypeAndAcademicYearAsync(classId, feeType, academicYear);
        return feeStructure != null ? MapToDto(feeStructure) : null;
    }

    public async Task<FeeStructureDto> CreateFeeStructureAsync(CreateFeeStructureDto createDto)
    {
        var classEntity = await _classRepository.GetByIdAsync(createDto.ClassId);
        if (classEntity == null)
            throw new ArgumentException("Class not found");

        var existingStructure = await _feeStructureRepository.GetByClassIdFeeTypeAndAcademicYearAsync(
            createDto.ClassId, createDto.FeeType, createDto.AcademicYear);

        if (existingStructure != null)
            throw new InvalidOperationException("Fee structure already exists for this class, fee type, and academic year");

        var feeStructure = new FeeStructure
        {
            ClassId = createDto.ClassId,
            FeeType = createDto.FeeType,
            Amount = createDto.Amount,
            AcademicYear = createDto.AcademicYear,
            Description = createDto.Description,
            IsActive = true
        };

        var createdStructure = await _feeStructureRepository.AddAsync(feeStructure);
        var createdStructureWithIncludes = await _feeStructureRepository.GetByIdAsync(createdStructure.Id);
        return MapToDto(createdStructureWithIncludes!);
    }

    public async Task<FeeStructureDto> UpdateFeeStructureAsync(int id, CreateFeeStructureDto updateDto)
    {
        var feeStructure = await _feeStructureRepository.GetByIdAsync(id);
        if (feeStructure == null)
            throw new ArgumentException("Fee structure not found");

        var classEntity = await _classRepository.GetByIdAsync(updateDto.ClassId);
        if (classEntity == null)
            throw new ArgumentException("Class not found");

        var existingStructure = await _feeStructureRepository.GetByClassIdFeeTypeAndAcademicYearAsync(
            updateDto.ClassId, updateDto.FeeType, updateDto.AcademicYear);

        if (existingStructure != null && existingStructure.Id != id)
            throw new InvalidOperationException("Fee structure already exists for this class, fee type, and academic year");

        feeStructure.ClassId = updateDto.ClassId;
        feeStructure.FeeType = updateDto.FeeType;
        feeStructure.Amount = updateDto.Amount;
        feeStructure.AcademicYear = updateDto.AcademicYear;
        feeStructure.Description = updateDto.Description;

        await _feeStructureRepository.UpdateAsync(feeStructure);

        var updatedStructureWithIncludes = await _feeStructureRepository.GetByIdAsync(id);
        return MapToDto(updatedStructureWithIncludes!);
    }

    public async Task DeleteFeeStructureAsync(int id)
    {
        await _feeStructureRepository.DeleteAsync(id);
    }

    private static FeeStructureDto MapToDto(FeeStructure feeStructure)
    {
        return new FeeStructureDto
        {
            Id = feeStructure.Id,
            ClassId = feeStructure.ClassId,
            ClassName = feeStructure.Class?.Name + " - " + feeStructure.Class?.Section ?? "",
            FeeType = feeStructure.FeeType,
            Amount = feeStructure.Amount,
            AcademicYear = feeStructure.AcademicYear,
            Description = feeStructure.Description,
            IsActive = feeStructure.IsActive
        };
    }
}