using Common.RabbitMQ.MassTransit;
using FluentValidation;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Authorization.Api;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .ConfigureSwagger()
            .ConfigureHealthChecks(configuration)
            .ConfigureFluentValidation()
            .ConfigureRabbitMQ(configuration);

    private static IServiceCollection ConfigureRabbitMQ(
        this IServiceCollection services,
        IConfiguration configuration)
        => services.AddMessageBroker(configuration);

    private static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        => services.AddValidatorsFromAssembly(typeof(Program).Assembly);

    private static IServiceCollection ConfigureHealthChecks(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Postgres"));

        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        => services.AddSwaggerGen(delegate (SwaggerGenOptions c)
        {
            c.CustomSchemaIds((x) => x.FullName);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Authorization API",
                Version = "v1"
            });
        });
}