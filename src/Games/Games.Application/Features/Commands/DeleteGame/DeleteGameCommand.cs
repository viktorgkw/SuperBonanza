using MediatR;

namespace Games.Application.Features.Commands.DeleteGame;

public class DeleteGameCommand : IRequest
{
    public string GameId { get; set; }
}