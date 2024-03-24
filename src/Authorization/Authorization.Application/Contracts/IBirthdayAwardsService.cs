namespace Authorization.Application.Contracts;

public interface IBirthdayAwardsService
{
    Task<int> AwardBirthdayPlayers(CancellationToken cancellationToken);
}