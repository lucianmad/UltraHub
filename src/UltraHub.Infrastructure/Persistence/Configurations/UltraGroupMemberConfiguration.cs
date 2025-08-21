using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraHub.Domain.Entities;

namespace UltraHub.Infrastructure.Persistence.Configurations;

public class UltraGroupMemberConfiguration : IEntityTypeConfiguration<UltraGroupMember>
{
    public void Configure(EntityTypeBuilder<UltraGroupMember> builder)
    {
        builder.ToTable("UltraGroupMembers");
        builder.HasKey(ugm => new {ugm.UltraGroupId, ugm.UserId});
        
        builder.HasOne(ugm => ugm.UltraGroup)
            .WithMany(ug => ug.UltraGroupMembers)
            .HasForeignKey(ugm => ugm.UltraGroupId);
    }
}