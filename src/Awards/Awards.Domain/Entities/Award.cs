using Awards.Domain.Enums;

namespace Awards.Domain.Entities;

public class Award
{
    public Guid Id { get; set; }

    public Guid PlayerId { get; set; }

    public AwardTypes Type { get; set; }
}