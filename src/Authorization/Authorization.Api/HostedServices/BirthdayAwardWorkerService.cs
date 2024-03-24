using Authorization.Application.Features.Commands.BirthdayAwards;
using Common.Configuration;
using MediatR;
using Microsoft.Extensions.Options;
using NCrontab;

namespace Authorization.Api.HostedServices;

public class BirthdayAwardWorkerService(
    IMediator mediator,
    IOptions<WorkerConfiguration> workerConfiguration,
    ILogger<BirthdayAwardWorkerService> logger)
    : BackgroundService
{
    private readonly IMediator _mediator = mediator;
    private readonly CrontabSchedule _schedule = CrontabSchedule.Parse(workerConfiguration.Value.CronSchedule);
    private readonly ILogger<BirthdayAwardWorkerService> _logger = logger;

    private DateTime _nextRun = DateTime.UtcNow;

    private const int SecondsToWait = 3600;
    private const int SecondInMilliseconds = 1000;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();

        _logger.LogInformation("{ServiceName} has started.", typeof(BirthdayAwardWorkerService).Name);

        try
        {
            if (DateTime.UtcNow > _nextRun)
            {
                var count = await _mediator.Send(new BirthdayAwardsCommand(), cancellationToken);

                _logger.LogInformation("{Count} birthday awards were given.", count);

                _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
            }

            _logger.LogInformation("Next run at {NextRun}", _nextRun.ToShortDateString());

            // Wait another hour
            await Task.Delay(SecondsToWait * SecondInMilliseconds, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(
                "An error ocurred in {ServiceName}!\n{Exception}",
                typeof(BirthdayAwardWorkerService).Name,
                ex);

            // Wait 5 minutes if an error occurs
            await Task.Delay(300_000, cancellationToken);
        }
    }
}
