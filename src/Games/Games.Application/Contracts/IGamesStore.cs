using Games.Domain.Entities;

namespace Games.Application.Contracts;

public interface IGamesStore
{
    Task ClearAllGames(IEnumerable<Game> games, CancellationToken cancellationToken);

    Task UploadGames(IEnumerable<Game> games, CancellationToken cancellationToken);
}