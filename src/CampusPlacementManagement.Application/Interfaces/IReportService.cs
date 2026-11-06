using CampusPlacementManagement.Application.DTOs.Reports;
namespace CampusPlacementManagement.Application.Interfaces;
public interface IReportService
{
    Task<PlatformReportDto> GetPlatformReportAsync();
}
