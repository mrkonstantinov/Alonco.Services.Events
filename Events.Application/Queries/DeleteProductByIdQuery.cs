using MediatR;

namespace Events.Application.Queries;

public class DeleteEventByIdQuery : IRequest<bool>
{
    public string Id { get; set; }

    public DeleteEventByIdQuery(string id)
    {
        Id = id;
    }
}