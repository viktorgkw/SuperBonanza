using Games.Application.Contracts;
using Games.Infrastructure.Persistence;
using Games.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddDatabase()
            .AddServices();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<GamesDbContext>(options =>
        {
            options
                .UseInMemoryDatabase("SuperBonanza");
        }, ServiceLifetime.Transient);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGamesService, GamesService>();

        return services;
    }
}