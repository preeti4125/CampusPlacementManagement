using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;

namespace CampusPlacementManagement.Application.Services;

public class CollegeService : ICollegeService
{
    private readonly ICollegeRepository _collegeRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CollegeService(ICollegeRepository collegeRepo, IUnitOfWork unitOfWork)
    {
        _collegeRepo = collegeRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<College>> GetAllCollegesAsync() => await _collegeRepo.GetAllAsync();

    public async Task<College> CreateCollegeAsync(CreateCollegeDto dto)
    {
        var college = new College
        {
            CollegeName = dto.CollegeName,
            CollegeCode = dto.CollegeCode,
            UniversityName = dto.UniversityName,
            OfficialEmail = dto.OfficialEmail,
            Address = dto.Address,
            Website = dto.Website
        };
        await _collegeRepo.AddAsync(college);
        await _unitOfWork.CompleteAsync();
        return college;
    }
}
