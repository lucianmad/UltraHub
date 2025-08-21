namespace UltraHub.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    
    public IEnumerable<UltraGroup> UltraGroups { get; set; } = new List<UltraGroup>();
    public IEnumerable<Match> HomeMatches { get; set; } = new List<Match>();
    public IEnumerable<Match> AwayMatches { get; set; } = new List<Match>();
}