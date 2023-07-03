using Events.Application.Responses;
using MediatR;

namespace Events.Application.Queries;

public class GetAllTagsQuery : IRequest<IList<TagResponse>>
{
    
}