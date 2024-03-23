using Entertainment.Application.Contracts;
using Entertainment.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Entertainment.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        => services.ConfigureServices();

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services
            .AddScoped<IJokeService, JokeService>();
}