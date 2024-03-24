using Awards.Application.Contracts;
using Awards.Infrastructure.Persistence;
using Awards.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Awards.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .ConfigureServices()
            .ConfigurePostgreSQL(configuration);

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services.AddTransient<IAwardsService, AwardsService>();

    private static IServiceCollection ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<AwardsDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseLazyLoadingProxies();
        }, ServiceLifetime.Transient);

        return services;
    }
}