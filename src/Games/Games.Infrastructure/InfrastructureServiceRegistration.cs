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
        services.AddDbContext<GamesDbContext>(options =>
        {
            options
                .UseInMemoryDatabase("SuperBonanza");
        }, ServiceLifetime.Transient);

        services.AddScoped<IGamesService, GamesService>();

        return services;
    }
}