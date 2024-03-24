using Authorization.Application.Contracts;
using Authorization.Infrastructure.Persistence;
using Common.RabbitMQ.Enums;
using Common.RabbitMQ.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Infrastructure.Services;

public class BirthdayAwardsService(
    AuthDbContext context,
    IPublishEndpoint publishEndpoint)
    : IBirthdayAwardsService
{
    private readonly AuthDbContext _context = context;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<int> AwardBirthdayPlayers(CancellationToken cancellationToken)
    {
        var celebrating = await _context.Users
            .Where(u => u.BirthDate.Date == DateTime.Today)
            .Select(p => new PlayerAwardEvent
            {
                PlayerId = p.Id,
                AwardType = AwardTypes.Birthday
            })
            .ToListAsync(cancellationToken: cancellationToken);

        if (celebrating.Count > 0)
            await _publishEndpoint.PublishBatch(celebrating, cancellationToken);

        return celebrating.Count;
    }
}