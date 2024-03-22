using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Queries.ClearAllGames;

public class ClearAllGamesCommand : IRequest
{
    public IEnumerable<Game> Games { get; set; }
}