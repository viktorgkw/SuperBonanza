using Impressions.Domain.Entities;
using MediatR;

namespace Impressions.Application.Features.Commands.AddImpression;

public class AddImpressionCommand : IRequest
{
    public Impression Impression { get; set; }
}