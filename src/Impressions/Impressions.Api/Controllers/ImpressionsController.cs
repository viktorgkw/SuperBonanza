using Impressions.Application.Features.Commands.AddImpression;
using Impressions.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Impressions.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImpressionsController(IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> AddImpression(Impression impression)
    {
        await _mediator.Send(new AddImpressionCommand
        {
            Impression = impression
        });

        return NoContent();
    }
}