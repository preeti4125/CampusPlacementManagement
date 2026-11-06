using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Application.Services;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Core.Interfaces.Services;
using CampusPlacementManagement.Infrastructure.Data;
using CampusPlacementManagement.Infrastructure.Identity;
using CampusPlacementManagement.Infrastructure.Repositories;
using CampusPlacementManagement.Api.Services;
using CampusPlacementManagement.Api.Authorization.Handlers;
using CampusPlacementManagement.Api.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace CampusPlacementManagement.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlacementServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<ITokenService, TokenService>();

        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICollegeRepository, CollegeRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IJobOpeningRepository, JobOpeningRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<IPlacementOfficerRepository, PlacementOfficerRepository>();
        services.AddScoped<ICompanyHRRepository, CompanyHRRepository>();
        services.AddScoped<IRecruitmentDriveRepository, RecruitmentDriveRepository>();
        services.AddScoped<IInterviewRepository, InterviewRepository>();

        // Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICollegeService, CollegeService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IInterviewService, InterviewService>();
        services.AddScoped<IReportService, ReportService>();

        // Authorization Handlers
        services.AddScoped<IAuthorizationHandler, SameCollegeHandler>();
        services.AddScoped<IAuthorizationHandler, SameCompanyHandler>();

        return services;
    }
}
