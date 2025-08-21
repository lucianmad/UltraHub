using UltraHub.Domain.Enums;

namespace UltraHub.Domain.Entities;

public class UltraGroupMember
{
    public int UserId { get; set; }
    public int UltraGroupId { get; set; }
    public GroupRole Role { get; set; }
    public MembershipStatus Status { get; set; }
    
    public User User { get; set; } = null!;
    public UltraGroup UltraGroup { get; set; } = null!;
}