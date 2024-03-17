using Impressions.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Impressions.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
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