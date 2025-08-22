using UltraHub.Domain.Entities;

namespace UltraHub.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<bool> IsUsernameAvailableAsync(string username);
    Task<bool> IsEmailAvailableAsync(string email);
    Task AddAsync(User user);
}