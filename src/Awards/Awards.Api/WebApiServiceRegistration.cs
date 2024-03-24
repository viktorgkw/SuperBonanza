using FluentValidation;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Awards.Api;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        => services
            .ConfigureSwagger()
            .ConfigureFluentValidation();

    private static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        => services.AddValidatorsFromAssembly(typeof(Program).Assembly);

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        => services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            c.CustomSchemaIds((x) => x.FullName);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Awards API",
                Version = "v1"
            });
        });
}