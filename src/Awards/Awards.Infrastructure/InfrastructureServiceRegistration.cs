using Microsoft.Extensions.DependencyInjection;

namespace Awards.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        => services.ConfigureServices();

    private static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services;
}