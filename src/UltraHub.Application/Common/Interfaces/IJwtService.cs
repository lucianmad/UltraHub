using UltraHub.Domain.Enums;

namespace UltraHub.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateToken(int userId, Role role, string username, string email);
}