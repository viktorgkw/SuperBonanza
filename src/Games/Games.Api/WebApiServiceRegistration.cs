using Common.Configuration;
using FluentValidation;
using Games.Api.HostedServices;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Games.Api;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .ConfigureSwagger()
            .ConfigureHealthChecks(configuration)
            .ConfigureFluentValidation()
            .ConfigureHostedServices()
            .AddWorkerConfiguration(configuration);

    private static IServiceCollection AddWorkerConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services.AddSingleton(Options.Create(configuration.GetSection(nameof(WorkerConfiguration)).Get<WorkerConfiguration>()));

    private static IServiceCollection ConfigureHostedServices(this IServiceCollection services)
        => services
            .AddSingleton<GamesCacherWorkerServices>()
            .AddHostedService<GamesCacherWorkerServices>();

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
            c.CustomSchemaIds((Type x) => x.FullName);
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Games API",
                Version = "v1"
            });
        });
}