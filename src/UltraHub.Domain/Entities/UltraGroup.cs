namespace UltraHub.Domain.Entities;

public class UltraGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public int TeamId { get; set; }
    
    public Team Team { get; set; } = null!;
    public IEnumerable<UltraGroupMember> UltraGroupMembers { get; set; } = new List<UltraGroupMember>();
    public IEnumerable<Moment> Moments { get; set; } = new List<Moment>();
}