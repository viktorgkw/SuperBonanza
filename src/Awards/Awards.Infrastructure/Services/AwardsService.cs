using AutoMapper;
using Awards.Application.Contracts;
using Awards.Domain.Entities;
using Awards.Infrastructure.Persistence;
using Common.RabbitMQ.Events;

namespace Awards.Infrastructure.Services;

public class AwardsService(
    AwardsDbContext context,
    IMapper mapper)
    : IAwardsService
{
    private readonly AwardsDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task StoreAward(PlayerAwardEvent playerAward)
    {
        await _context.Awards.AddAsync(_mapper.Map<Award>(playerAward));
        await _context.SaveChangesAsync();
    }
}