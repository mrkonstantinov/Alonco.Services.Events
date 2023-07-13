using EventCatalog.Application.Mappers;
using EventCatalog.Application.Queries;
using EventCatalog.Application.Responses;
using EventCatalog.Core.Entities;
using EventCatalog.Core.Repositories;
using MediatR;

namespace EventCatalog.Application.Handlers;

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