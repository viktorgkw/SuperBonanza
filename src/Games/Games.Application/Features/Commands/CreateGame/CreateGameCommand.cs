using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Commands.CreateGame;

public class CreateGameCommand : IRequest
{
    public Game Game { get; set; }
}