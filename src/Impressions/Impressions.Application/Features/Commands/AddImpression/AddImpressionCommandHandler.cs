using Impressions.Application.Contracts;
using MediatR;

namespace Impressions.Application.Features.Commands.AddImpression;

public class AddImpressionCommandHandler(IImpressionsService impressionsService)
    : IRequestHandler<AddImpressionCommand>
{
    private readonly IImpressionsService _impressionsService = impressionsService;

    public async Task Handle(AddImpressionCommand request, CancellationToken cancellationToken)
        => await _impressionsService.AddImpression(request.Impression, cancellationToken);
}