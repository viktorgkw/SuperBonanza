using Common.Behaviors;
using Impressions.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Impressions.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
         => services
             .ConfigureRedisStoreSettings(configuration)
             .ConfigureMediator();

    private static IServiceCollection ConfigureRedisStoreSettings(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<RedisStoreSettings>(configuration.GetSection(nameof(RedisStoreSettings)));

    private static IServiceCollection ConfigureMediator(this IServiceCollection services)
        => services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
}