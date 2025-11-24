using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Extensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IAppDbContext, AppDbContext>(options=>
            options.UseNpgsql(connectionString));
        return services;
    }
}
