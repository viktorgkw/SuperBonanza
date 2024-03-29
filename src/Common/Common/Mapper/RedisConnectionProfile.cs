﻿using AutoMapper;
using Common.Configuration;
using StackExchange.Redis;

namespace Common.Mapper;

public class RedisConnectionProfile : Profile
{
    public RedisConnectionProfile()
    {
        CreateMap<RedisConnectionConfig, ConfigurationOptions>()
            .ForMember(c => c.EndPoints, opt => opt.MapFrom(src => new EndPointCollection() { $"{src.Host}:{src.Port}" }))
            .ForMember(c => c.Ssl, opt => opt.MapFrom(_ => true))
            .ForMember(c => c.AllowAdmin, opt => opt.MapFrom(_ => true));
    }
}