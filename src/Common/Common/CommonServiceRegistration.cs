using Common.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common;

public static class CommonServiceRegistration
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
        => services
            .ConfigureMapper()
            .ConfigureGlobalExceptionHandler();

    private static IServiceCollection ConfigureMapper(this IServiceCollection services)
        => services.AddAutoMapper(Assembly.GetExecutingAssembly());

    private static IServiceCollection ConfigureGlobalExceptionHandler(this IServiceCollection services)
        => services
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails();
}