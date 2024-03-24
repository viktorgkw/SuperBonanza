using Common.RabbitMQ.Enums;

namespace Common.RabbitMQ.Events;

public record PlayerAwardEvent : IntegratorEvent
{
    public Guid PlayerId { get; set; }

    public AwardTypes AwardType { get; set; }
}