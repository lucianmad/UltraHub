using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraHub.Domain.Entities;

namespace UltraHub.Infrastructure.Persistence.Configurations;

public class MomentConfiguration : IEntityTypeConfiguration<Moment>
{
    public void Configure(EntityTypeBuilder<Moment> builder)
    {
        builder.ToTable("Moments");
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Text).IsRequired().HasMaxLength(255);
        builder.Property(m => m.MediaUrl).IsRequired().HasMaxLength(255);
        builder.Property(m => m.CreatedAt).IsRequired();
        builder.Property(m => m.Type).IsRequired();

        builder.HasOne(m => m.UltraGroup)
            .WithMany(ug => ug.Moments)
            .HasForeignKey(m => m.UltraGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(m => m.Match)
            .WithMany(m => m.Moments)
            .HasForeignKey(m => m.MatchId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(m => m.User)
            .WithMany(u => u.Moments)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}