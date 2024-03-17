using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace Common.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("[Start] {requestName} started.\n{request}", typeof(TRequest).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();

        if (timer.Elapsed.Seconds > 15)
        {
            _logger.LogCritical("[Performance] Request took {seconds} seconds!", timer.Elapsed.Seconds);
        }
        else if (timer.Elapsed.Seconds > 10)
        {
            _logger.LogError("[Performance] Request took {seconds} seconds!", timer.Elapsed.Seconds);
        }
        else if (timer.Elapsed.Seconds > 5)
        {
            _logger.LogWarning("[Performance] Request took {seconds} seconds!", timer.Elapsed.Seconds);
        }

        _logger.LogInformation("[Finish] {requestName} finished with response {response}.", typeof(TRequest).Name, JsonSerializer.Serialize(response,
            new JsonSerializerOptions
            {
                WriteIndented = true,
            }));

        return response;
    }
}