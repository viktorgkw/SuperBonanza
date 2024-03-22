using Impressions.Domain.Entities;

namespace Impressions.Application.Contracts;

public interface IImpressionsService
{
    Task AddImpression(Impression impression, CancellationToken cancellationToken);
}