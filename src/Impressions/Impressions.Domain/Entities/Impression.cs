using Impressions.Domain.Enums;

namespace Impressions.Domain.Entities;

public class Impression
{
    public Guid Id { get; set; }

    public Guid GameId { get; set; }

    public Guid PlayerId { get; set; }

    public ImpressionType Type { get; set; }
}