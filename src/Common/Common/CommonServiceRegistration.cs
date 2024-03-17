using Common.Handlers;
using Common.Providers.Redis;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common;

public static class CommonServiceRegistration
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });

        services.AddEndpointsApiExplorer();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSingleton<IRedisProvider, RedisProvider>();

        services
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails();

        return services;
    }
}