using FluentValidation;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Impressions.Api;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Postgres"));

        services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            c.CustomSchemaIds((x) => x.FullName);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Impressions API",
                Version = "v1"
            });
        });

        return services;
    }
}