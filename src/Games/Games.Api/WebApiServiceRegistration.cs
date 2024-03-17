using FluentValidation;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Games.Api;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddHealthChecks();

        services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            c.CustomSchemaIds((Type x) => x.FullName);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Games API",
                Version = "v1"
            });
        });

        return services;
    }
}