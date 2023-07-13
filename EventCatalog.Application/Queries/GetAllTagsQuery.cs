using EventCatalog.Application.Responses;
using MediatR;

namespace EventCatalog.Application.Queries;

public class GetAllTagsQuery : IRequest<IList<TagResponse>>
{
    
}