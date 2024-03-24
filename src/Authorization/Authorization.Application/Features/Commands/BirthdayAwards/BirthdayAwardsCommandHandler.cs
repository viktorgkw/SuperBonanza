using Authorization.Application.Contracts;
using MediatR;

namespace Authorization.Application.Features.Commands.BirthdayAwards;

public class BirthdayAwardsCommandHandler(
    IBirthdayAwardsService birthdayAwardsService)
    : IRequestHandler<BirthdayAwardsCommand, int>
{
    private readonly IBirthdayAwardsService _birthdayAwardsService = birthdayAwardsService;

    public async Task<int> Handle(
        BirthdayAwardsCommand request,
        CancellationToken cancellationToken)
        => await _birthdayAwardsService.AwardBirthdayPlayers(cancellationToken);
}