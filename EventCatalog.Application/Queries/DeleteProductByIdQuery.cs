using MediatR;

namespace EventCatalog.Application.Queries;

public class DeleteEventByIdQuery : IRequest<bool>
{
    public string Id { get; set; }

    public DeleteEventByIdQuery(string id)
    {
        Id = id;
    }
}