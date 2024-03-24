using Awards.Application.Contracts;
using Common.RabbitMQ.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Awards.Application.Features.EventHandlers.PlayerAward;

public class PlayerAwardEventHandler(
    IAwardsService awardsService,
    ILogger<PlayerAwardEventHandler> logger)
    : IConsumer<PlayerAwardEvent>
{
    private readonly IAwardsService _awardsService = awardsService;
    private readonly ILogger<PlayerAwardEventHandler> _logger = logger;

    public async Task Consume(ConsumeContext<PlayerAwardEvent> context)
    {
        _logger.LogInformation("Consumed {EventType}", context.Message.GetType().Name);
        await _awardsService.StoreAward(context.Message);
    }
}