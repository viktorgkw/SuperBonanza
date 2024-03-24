using Authorization.Application.Contracts;
using Authorization.Infrastructure.Persistence;
using Authorization.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .ConfigureServices()
            .ConfigurePostgreSQL(configuration);

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services
            .AddTransient<IAuthorizationService, AuthorizationService>()
            .AddTransient<IBirthdayAwardsService, BirthdayAwardsService>();

    private static IServiceCollection ConfigurePostgreSQL(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<AuthDbContext>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseLazyLoadingProxies();
        }, ServiceLifetime.Transient);

        return services;
    }
}