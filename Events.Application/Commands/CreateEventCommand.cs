using Events.Application.Responses;
using Events.Core.Entities;
using MediatR;

namespace Events.Application.Commands;

public class CreateEventCommand: IRequest<EventResponse>
{
    public string Name { get; set; }
}