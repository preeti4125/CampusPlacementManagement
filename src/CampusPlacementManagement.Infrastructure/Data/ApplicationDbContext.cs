using CampusPlacementManagement.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<College> Colleges => Set<College>();
    public DbSet<PlacementOfficer> PlacementOfficers => Set<PlacementOfficer>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyHR> CompanyHRs => Set<CompanyHR>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<JobOpening> JobOpenings => Set<JobOpening>();
    public DbSet<JobTargetCollege> JobTargetColleges => Set<JobTargetCollege>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<RecruitmentDrive> RecruitmentDrives => Set<RecruitmentDrive>();
    public DbSet<InterviewRound> InterviewRounds => Set<InterviewRound>();
    public DbSet<InterviewSchedule> InterviewSchedules => Set<InterviewSchedule>();
    public DbSet<ApplicationStatusHistory> ApplicationStatusHistories => Set<ApplicationStatusHistory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Explicit Primary Keys
        builder.Entity<College>().HasKey(c => c.CollegeId);
        builder.Entity<PlacementOfficer>().HasKey(p => p.PlacementOfficerId);
        builder.Entity<Company>().HasKey(c => c.CompanyId);
        builder.Entity<CompanyHR>().HasKey(h => h.CompanyHRId);
        builder.Entity<Student>().HasKey(s => s.StudentId);
        builder.Entity<JobOpening>().HasKey(j => j.JobId);
        builder.Entity<JobTargetCollege>().HasKey(t => t.JobTargetCollegeId);
        builder.Entity<JobApplication>().HasKey(a => a.ApplicationId);
        builder.Entity<RecruitmentDrive>().HasKey(d => d.DriveId);
        builder.Entity<InterviewRound>().HasKey(r => r.RoundId);
        builder.Entity<InterviewSchedule>().HasKey(s => s.ScheduleId);
        builder.Entity<ApplicationStatusHistory>().HasKey(h => h.HistoryId);

        // One-to-one user profiles
        builder.Entity<PlacementOfficer>()
            .HasOne(p => p.User)
            .WithOne(u => u.PlacementOfficer)
            .HasForeignKey<PlacementOfficer>(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<CompanyHR>()
            .HasOne(h => h.User)
            .WithOne(u => u.CompanyHR)
            .HasForeignKey<CompanyHR>(h => h.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Student>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Student relationships
        builder.Entity<Student>()
            .HasOne(s => s.College)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.CollegeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Student>()
            .HasOne(s => s.PlacementOfficer)
            .WithMany(p => p.EnrolledStudents)
            .HasForeignKey(s => s.PlacementOfficerId)
            .OnDelete(DeleteBehavior.Restrict);

        // JobOpening relationships - Prevent multiple cascade paths
        builder.Entity<JobOpening>()
            .HasOne(j => j.Company)
            .WithMany(c => c.JobOpenings)
            .HasForeignKey(j => j.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<JobOpening>()
            .HasOne(j => j.CreatedByHR)
            .WithMany(h => h.CreatedJobs)
            .HasForeignKey(j => j.CreatedByHRId)
            .OnDelete(DeleteBehavior.Restrict);

        // RecruitmentDrive & InterviewRound cascade prevention
        builder.Entity<RecruitmentDrive>()
            .HasOne(d => d.JobOpening)
            .WithMany(j => j.RecruitmentDrives)
            .HasForeignKey(d => d.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<InterviewRound>()
            .HasOne(r => r.JobOpening)
            .WithMany(j => j.InterviewRounds)
            .HasForeignKey(r => r.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<InterviewRound>()
            .HasOne(r => r.RecruitmentDrive)
            .WithMany(d => d.InterviewRounds)
            .HasForeignKey(r => r.DriveId)
            .OnDelete(DeleteBehavior.Restrict);

        // InterviewSchedule relationships
        builder.Entity<InterviewSchedule>()
            .HasOne(s => s.JobApplication)
            .WithMany(a => a.InterviewSchedules)
            .HasForeignKey(s => s.ApplicationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<InterviewSchedule>()
            .HasOne(s => s.InterviewRound)
            .WithMany(r => r.InterviewSchedules)
            .HasForeignKey(s => s.RoundId)
            .OnDelete(DeleteBehavior.Restrict);

        // JobApplication relationships
        builder.Entity<JobApplication>()
            .HasOne(a => a.Student)
            .WithMany(s => s.Applications)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<JobApplication>()
            .HasOne(a => a.JobOpening)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<JobApplication>()
            .HasIndex(a => new { a.JobId, a.StudentId })
            .IsUnique();

        // ApplicationStatusHistory
        builder.Entity<ApplicationStatusHistory>()
            .HasOne(h => h.JobApplication)
            .WithMany(a => a.StatusHistories)
            .HasForeignKey(h => h.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);

        // JobTargetCollege composite index & relations
        builder.Entity<JobTargetCollege>()
            .HasIndex(j => new { j.JobId, j.CollegeId })
            .IsUnique();

        builder.Entity<JobTargetCollege>()
            .HasOne(t => t.JobOpening)
            .WithMany(j => j.TargetColleges)
            .HasForeignKey(t => t.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<JobTargetCollege>()
            .HasOne(t => t.College)
            .WithMany()
            .HasForeignKey(t => t.CollegeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Precisions
        builder.Entity<Student>()
            .Property(s => s.CGPA)
            .HasPrecision(4, 2);

        builder.Entity<JobOpening>()
            .Property(j => j.SalaryPackage)
            .HasPrecision(18, 2);

        builder.Entity<JobOpening>()
            .Property(j => j.MinimumCGPA)
            .HasPrecision(4, 2);
    }
}
