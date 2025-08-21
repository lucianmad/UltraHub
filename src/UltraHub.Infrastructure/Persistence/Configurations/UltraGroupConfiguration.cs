using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraHub.Domain.Entities;

namespace UltraHub.Infrastructure.Persistence.Configurations;

public class UltraGroupConfiguration : IEntityTypeConfiguration<UltraGroup>
{
    public void Configure(EntityTypeBuilder<UltraGroup> builder)
    {
        builder.ToTable("UltraGroups");
        builder.HasKey(ug => ug.Id);
        
        builder.Property(ug => ug.Name).IsRequired().HasMaxLength(50);
        builder.Property(ug => ug.LogoUrl).IsRequired().HasMaxLength(255);
        
        builder.HasOne(ug => ug.Team)
            .WithMany(t => t.UltraGroups)
            .HasForeignKey(ug => ug.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}