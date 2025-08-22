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
    
    public async Task<bool> IsUsernameAvailableAsync(string username)
    {
        if (await _context.Users.AnyAsync(x => x.Username == username))
        {
            return false;
        }
        return true;
    }
    
    public async Task<bool> IsEmailAvailableAsync(string email)
    {
        if (await _context.Users.AnyAsync(x => x.Email == email))
        {
            return false;
        }
        return true;
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}