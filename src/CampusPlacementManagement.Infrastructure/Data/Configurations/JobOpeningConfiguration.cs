using CampusPlacementManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CampusPlacementManagement.Infrastructure.Data.Configurations;
public class JobOpeningConfiguration : IEntityTypeConfiguration<JobOpening>
{
    public void Configure(EntityTypeBuilder<JobOpening> builder)
    {
        builder.HasKey(j => j.JobId);
        builder.Property(j => j.SalaryPackage).HasPrecision(18, 2);
        builder.Property(j => j.MinimumCGPA).HasPrecision(4, 2);
    }
}
