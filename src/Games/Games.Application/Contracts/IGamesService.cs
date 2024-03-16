using Games.Domain.Entities;

namespace Games.Application.Contracts;

public interface IGamesService
{
    Task CreateGame(Game game, CancellationToken cancellationToken);

    Task DeleteGame(string gameId, CancellationToken cancellationToken);

    Task<IEnumerable<Game>> GetAllGames(CancellationToken cancellationToken);

    Task<Game> GetGameById(string gameId, CancellationToken cancellationToken);
}