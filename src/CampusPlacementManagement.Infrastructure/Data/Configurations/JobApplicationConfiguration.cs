using CampusPlacementManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CampusPlacementManagement.Infrastructure.Data.Configurations;
public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(a => a.ApplicationId);
        builder.HasIndex(a => new { a.JobId, a.StudentId }).IsUnique();
    }
}
