using UltraHub.Domain.Enums;

namespace UltraHub.Domain.Entities;

public class Moment
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string MediaUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public MomentType Type { get; set; }
    public int UltraGroupId { get; set; }
    public int MatchId { get; set; }
    public int UserId { get; set; }
    
    public UltraGroup UltraGroup { get; set; } = null!;
    public Match Match { get; set; } = null!;
    public User User { get; set; } = null!;
}