using Events.Application.Commands;
using Events.Application.Mappers;
using Events.Application.Responses;
using Events.Core.Entities;
using Events.Core.Repositories;
using MediatR;

namespace Events.Application.Handlers;

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