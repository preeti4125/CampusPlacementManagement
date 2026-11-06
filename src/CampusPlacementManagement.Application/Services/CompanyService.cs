using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Core.Interfaces.Repositories;

namespace CampusPlacementManagement.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyService(ICompanyRepository companyRepo, IUnitOfWork unitOfWork)
    {
        _companyRepo = companyRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<Company>> GetAllCompaniesAsync() => await _companyRepo.GetAllAsync();

    public async Task<Company> CreateCompanyAsync(CreateCompanyDto dto)
    {
        var company = new Company
        {
            CompanyName = dto.CompanyName,
            CompanyEmail = dto.CompanyEmail,
            Website = dto.Website,
            Industry = dto.Industry,
            Address = dto.Address,
            Description = dto.Description,
            Status = (AccountStatus)1
        };
        await _companyRepo.AddAsync(company);
        await _unitOfWork.CompleteAsync();
        return company;
    }
}
