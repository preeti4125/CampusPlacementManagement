using CampusPlacementManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CampusPlacementManagement.Infrastructure.Data.Configurations;
public class CollegeConfiguration : IEntityTypeConfiguration<College>
{
    public void Configure(EntityTypeBuilder<College> builder)
    {
        builder.HasKey(c => c.CollegeId);
        builder.HasIndex(c => c.CollegeCode).IsUnique();
    }
}
