using CampusPlacementManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _report;
    public ReportsController(IReportService report) => _report = report;

    [HttpGet("platform")]
    public async Task<IActionResult> GetPlatformReport() => Ok(await _report.GetPlatformReportAsync());
}
