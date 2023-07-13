using EventCatalog.Application.Commands;
using EventCatalog.Application.Mappers;
using EventCatalog.Application.Responses;
using EventCatalog.Core.Entities;
using EventCatalog.Core.Repositories;
using MediatR;

namespace EventCatalog.Application.Handlers;

public class CreateEventHandler : IRequestHandler<CreateEventCommand, EventResponse>
{
    private readonly IEventRepository _eventRepository;

    public CreateEventHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task<EventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var eventEntity = EventMapper.Mapper.Map<Event>(request);
        if (eventEntity is null)
        {
            throw new ApplicationException("There is an issue with mapping while creating new event");
        }

        var newEvent = await _eventRepository.CreateEvent(eventEntity);
        var eventResponse = EventMapper.Mapper.Map<EventResponse>(newEvent);
        return eventResponse;
    }
}