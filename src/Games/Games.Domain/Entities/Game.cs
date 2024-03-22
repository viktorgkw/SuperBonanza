using MessagePack;

namespace Games.Domain.Entities;

[MessagePackObject]
public class Game
{
    [Key(0)]
    public Guid Id { get; set; }

    [Key(1)]
    public string Name { get; set; }

    [Key(2)]
    public string Description { get; set; }
}