using AutoMapper;
using EventCatalog.Application.Commands;
using EventCatalog.Application.Responses;
using EventCatalog.Core.Entities;

namespace EventCatalog.Application.Mappers;

public class EventMappingProfile : Profile
{
    public EventMappingProfile()
    {
        CreateMap<Tag, TagResponse>().ReverseMap();

    }
}