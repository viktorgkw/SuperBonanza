using AutoMapper;
using Awards.Domain.Entities;
using Common.RabbitMQ.Events;

namespace Awards.Application.Mapping;

public class AwardsProfile : Profile
{
    public AwardsProfile()
    {
        CreateMap<PlayerAwardEvent, Award>();
    }
}