using Common.Configuration;
using Games.Application.Features.Commands.UploadGames;
using Games.Application.Features.Queries.ClearAllGames;
using Games.Application.Features.Queries.GetAllGames;
using MediatR;
using Microsoft.Extensions.Options;
using NCrontab;

namespace Games.Api.HostedServices;

/// <summary>
/// Stores all the existing games in redis and removes the previous ones.
/// </summary>
public class GamesCacherWorkerServices(
    IMediator mediator,
    IOptions<WorkerConfiguration> workerConfiguration)
    : BackgroundService
{
    private readonly IMediator _mediator = mediator;
    private readonly CrontabSchedule _schedule = CrontabSchedule.Parse(workerConfiguration.Value.CronSchedule);

    private DateTime _nextRun = DateTime.UtcNow;

    private const int SecondsToWait = 3600;
    private const int SecondInMilliseconds = 1000;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();

        try
        {
            if (DateTime.UtcNow > _nextRun)
            {
                var games = await _mediator.Send(new GetAllGamesQuery(), cancellationToken);

                await _mediator.Send(new ClearAllGamesCommand
                {
                    Games = games
                }, cancellationToken);

                await _mediator.Send(new UploadGamesCommand
                {
                    Games = games
                }, cancellationToken);

                _nextRun = _schedule.GetNextOccurrence(DateTime.UtcNow);
            }

            // Wait another hour
            await Task.Delay(SecondsToWait * SecondInMilliseconds, cancellationToken);
        }
        catch (Exception ex)
        {
            // log exception

            // Wait 5 minutes if an error occurs
            await Task.Delay(300_000, cancellationToken);
        }
    }
}