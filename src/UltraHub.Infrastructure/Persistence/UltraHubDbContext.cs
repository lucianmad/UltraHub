using Microsoft.EntityFrameworkCore;
using UltraHub.Domain.Entities;

namespace UltraHub.Infrastructure.Persistence;

public class UltraHubDbContext : DbContext
{
    public UltraHubDbContext(DbContextOptions<UltraHubDbContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<UltraGroup> UltraGroups { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Moment> Moments { get; set; }
    public DbSet<UltraGroupMember> UltraGroupMembers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UltraHubDbContext).Assembly);
    }
}