using Common.Providers.Redis;
using Games.Application.Contracts;
using Games.Infrastructure.Persistence;
using Games.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<GamesDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseLazyLoadingProxies();
        }, ServiceLifetime.Transient);

        services.AddScoped<IGamesService, GamesService>();

        services.AddSingleton<IRedisProvider, RedisProvider>();

        return services;
    }
}