using Common.Configuration;
using Common.Providers.Redis;
using Games.Application.Contracts;
using Games.Infrastructure.Persistence;
using Games.Infrastructure.Services;
using Games.Infrastructure.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .ConfigureServices(configuration)
            .ConfigurePostgreSQL(configuration);

    private static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddSingleton(configuration.GetSection(nameof(RedisConnectionConfig)).Get<RedisConnectionConfig>())
            .AddSingleton<IRedisProvider, RedisProvider>()
            .AddScoped<IGamesService, GamesService>()
            .AddScoped<IGamesStore, GamesStore>();

    private static IServiceCollection ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<GamesDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseLazyLoadingProxies();
        }, ServiceLifetime.Transient);

        return services;
    }
}