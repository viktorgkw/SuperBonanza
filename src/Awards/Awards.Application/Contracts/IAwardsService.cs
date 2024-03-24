using Common.RabbitMQ.Events;

namespace Awards.Application.Contracts;

public interface IAwardsService
{
    Task StoreAward(PlayerAwardEvent playerAward);
}