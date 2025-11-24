using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.Repositories;

namespace IdentityService.Infrastructure.Extensions;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IRefreshTokenRepository, RefreshTokeRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        return services;
    }
}
