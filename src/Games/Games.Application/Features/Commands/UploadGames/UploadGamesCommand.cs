using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Commands.UploadGames;

public class UploadGamesCommand : IRequest
{
    public IEnumerable<Game> Games { get; set; }
}