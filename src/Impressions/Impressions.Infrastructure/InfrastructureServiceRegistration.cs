using Impressions.Application.Contracts;
using Impressions.Infrastructure.Persistence;
using Impressions.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Impressions.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .ConfigureServices()
            .ConfigurePostgreSQL(configuration);

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services.AddTransient<IImpressionsService, ImpressionsService>();

    private static IServiceCollection ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<ImpressionsDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseLazyLoadingProxies();
        }, ServiceLifetime.Transient);

        return services;
    }
}