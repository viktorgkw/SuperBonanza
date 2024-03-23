using Entertainment.Domain.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Entertainment.Api;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .ConfigureSwagger()
            .ConfigureHealthChecks()
            .AddExternalProvidersConfiguration(configuration);

    private static IServiceCollection AddExternalProvidersConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services.AddSingleton(Options.Create(configuration.GetSection(nameof(ExternalProviders)).Get<ExternalProviders>()));

    private static IServiceCollection ConfigureHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks();

        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        => services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            c.CustomSchemaIds((x) => x.FullName);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Entertainment API",
                Version = "v1"
            });
        });
}