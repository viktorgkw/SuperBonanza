using Games.Application.Features.Commands.CreateGame;
using Games.Application.Features.Commands.DeleteGame;
using Games.Application.Features.Queries.GetAllGames;
using Games.Application.Features.Queries.GetGameById;
using Games.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Games.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController(IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [Route("all")]
    [ProducesResponseType(typeof(IEnumerable<Game>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllGames()
        => Ok(await _mediator.Send(new GetAllGamesQuery()));

    [HttpGet]
    [Route("{gameId}")]
    [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGameById(string gameId)
    {
        var game = await _mediator.Send(new GetGameByIdQuery
        {
            GameId = gameId
        });

        return game is null ? NotFound() : Ok(game);
    }

    [HttpDelete]
    [Route("{gameId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteGame(string gameId)
    {
        await _mediator.Send(new DeleteGameCommand
        {
            GameId = gameId
        });

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateGame([FromBody] Game game)
    {
        await _mediator.Send(new CreateGameCommand
        {
            Game = game
        });

        return NoContent();
    }
}