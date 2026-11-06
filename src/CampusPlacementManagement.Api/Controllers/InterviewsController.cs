using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InterviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public InterviewsController(ApplicationDbContext context) => _context = context;

    [HttpGet("schedules")]
    public async Task<IActionResult> GetSchedules() =>
        Ok(await _context.InterviewSchedules.Include(s => s.JobApplication).ToListAsync());

    [HttpPost("schedule")]
    public async Task<IActionResult> Schedule(ScheduleInterviewDto dto)
    {
        var schedule = new InterviewSchedule
        {
            ApplicationId = dto.ApplicationId,
            RoundId = dto.RoundId,
            ScheduledAt = dto.ScheduledAt,
            MeetingLinkOrVenue = dto.MeetingLinkOrVenue,
            Feedback = dto.Feedback,
            Status = InterviewStatus.Scheduled
        };
        _context.InterviewSchedules.Add(schedule);
        await _context.SaveChangesAsync();
        return Ok(schedule);
    }
}
