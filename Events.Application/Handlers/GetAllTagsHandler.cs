using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IList<TagResponse>>
{
    private readonly ITagsRepository _tagsRepository;
    
    public GetAllTagsHandler(ITagsRepository tagsRepository)
    {
        _tagsRepository = tagsRepository;
    }
    public async Task<IList<TagResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        var tagList = await _tagsRepository.GetAllTags();
        var tagResponseList = EventMapper.Mapper.Map<IList<Tag>, IList<TagResponse>>(tagList.ToList());
        return tagResponseList;
    }
}