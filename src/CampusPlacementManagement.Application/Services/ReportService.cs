using CampusPlacementManagement.Application.DTOs.Reports;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Interfaces.Repositories;
namespace CampusPlacementManagement.Application.Services;
public class ReportService : IReportService
{
    private readonly ICollegeRepository _colleges;
    private readonly ICompanyRepository _companies;
    private readonly IJobOpeningRepository _jobs;
    public ReportService(ICollegeRepository colleges, ICompanyRepository companies, IJobOpeningRepository jobs)
    {
        _colleges = colleges; _companies = companies; _jobs = jobs;
    }
    public async Task<PlatformReportDto> GetPlatformReportAsync()
    {
        var c = (await _colleges.GetAllAsync()).Count;
        var comp = (await _companies.GetAllAsync()).Count;
        var j = (await _jobs.GetAllAsync()).Count;
        return new PlatformReportDto(c, comp, j, 0, 0);
    }
}
