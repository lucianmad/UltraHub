using UltraHub.Domain.Enums;

namespace UltraHub.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public Role Role { get; set; }
    
    public IEnumerable<Moment> Moments { get; set; } = new List<Moment>();
}