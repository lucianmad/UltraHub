using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UltraHub.Application.Common.Interfaces;
using UltraHub.Domain.Entities;
using UltraHub.Infrastructure.Persistence.Repositories;
using UltraHub.Infrastructure.Services;

namespace UltraHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        
        return services;
    }
}