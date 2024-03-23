using Entertainment.Application.Features.Queries.GetRandomJoke;
using Entertainment.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Entertainment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EntertainmentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [Route("jokes/random")]
    [ProducesResponseType(typeof(Joke), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRandomJoke()
        => Ok(await _mediator.Send(new GetRandomJokeQuery()));
}