using Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Entertainment.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
            .ConfigureMediator();

    private static IServiceCollection ConfigureMediator(this IServiceCollection services)
        => services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
}