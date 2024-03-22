using Impressions.Application.Contracts;
using Impressions.Domain.Entities;
using Impressions.Infrastructure.Persistence;

namespace Impressions.Infrastructure.Services;

public class ImpressionsService(ImpressionsDbContext context)
    : IImpressionsService
{
    private readonly ImpressionsDbContext _context = context;

    public async Task AddImpression(Impression impression, CancellationToken cancellationToken)
    {
        await _context.Impressions.AddAsync(impression, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}