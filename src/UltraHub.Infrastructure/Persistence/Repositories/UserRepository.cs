using Microsoft.EntityFrameworkCore;
using UltraHub.Application.Common.Interfaces;
using UltraHub.Domain.Entities;

namespace UltraHub.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UltraHubDbContext _context;
    
    public UserRepository(UltraHubDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> IsUsernameAvailableAsync(string username, CancellationToken cancellationToken = default)
    {
        if (await _context.Users.AnyAsync(x => x.Username == username, cancellationToken: cancellationToken))
        {
            return false;
        }
        return true;
    }
    
    public async Task<bool> IsEmailAvailableAsync(string email, CancellationToken cancellationToken = default)
    {
        if (await _context.Users.AnyAsync(x => x.Email == email, cancellationToken: cancellationToken))
        {
            return false;
        }
        return true;
    }
    
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken: cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}