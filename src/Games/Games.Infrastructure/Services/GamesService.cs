using Games.Application.Contracts;
using Games.Domain.Entities;
using Games.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Games.Infrastructure.Services;

public class GamesService(GamesDbContext context)
    : IGamesService
{
    private readonly GamesDbContext _context = context;

    public async Task CreateGame(Game game, CancellationToken cancellationToken)
    {
        await _context.Games.AddAsync(game, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteGame(string gameId, CancellationToken cancellationToken)
    {
        await _context.Games
            .Where(g => g.Id.ToString() == gameId)
            .ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Game>> GetAllGames(CancellationToken cancellationToken)
        => await _context.Games
            .ToListAsync(cancellationToken: cancellationToken);

    public async Task<Game> GetGameById(string gameId, CancellationToken cancellationToken)
        => await _context.Games
            .FirstOrDefaultAsync(g => g.Id.ToString() == gameId, cancellationToken: cancellationToken);
}