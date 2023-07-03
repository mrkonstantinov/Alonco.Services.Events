using AutoMapper;
using Events.Application.Commands;
using Events.Application.Responses;
using Events.Core.Entities;

namespace Events.Application.Mappers;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<Tag, TagResponse>().ReverseMap();

    }
}