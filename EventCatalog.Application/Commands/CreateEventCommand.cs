using EventCatalog.Application.Responses;
using EventCatalog.Core.Entities;
using MediatR;

namespace EventCatalog.Application.Commands;

public class CreateEventCommand: IRequest<EventResponse>
{
    public string Name { get; set; }
}