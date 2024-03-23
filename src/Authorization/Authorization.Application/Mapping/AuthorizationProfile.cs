using Authorization.Domain.Entities;
using AutoMapper;

namespace Authorization.Application.Mapping;

public class AuthorizationProfile : Profile
{
    public AuthorizationProfile()
    {
        CreateMap<RegisterModel, AppUser>()
            .ForMember(u => u.Id, x => x.MapFrom(_ => Guid.NewGuid()))
            .ForMember(u => u.IsDeleted, x => x.MapFrom(_ => false))
            .ForMember(u => u.HashedPassword, x => x.MapFrom(m => m.Password));
    }
}