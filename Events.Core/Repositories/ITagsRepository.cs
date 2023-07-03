using Events.Core.Entities;

namespace Events.Core.Repositories;

public interface ITagsRepository
{
    Task<IEnumerable<Tag>> GetAllTags();
}