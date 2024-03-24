namespace Common.RabbitMQ.Events;

public record IntegratorEvent
{
    public Guid Id => Guid.NewGuid();

    public DateTime OccuredOn => DateTime.UtcNow;

    public string EventType => GetType().AssemblyQualifiedName;
}