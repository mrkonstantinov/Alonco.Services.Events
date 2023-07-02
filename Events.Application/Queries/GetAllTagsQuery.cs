using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllTagsQuery : IRequest<IList<TagResponse>>
{
    
}