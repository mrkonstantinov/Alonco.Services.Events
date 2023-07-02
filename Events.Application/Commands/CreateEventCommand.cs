using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands;

public class CreateEventCommand: IRequest<EventResponse>
{
    public string Name { get; set; }
}