using EventCatalog.Core.Entities;

namespace EventCatalog.Core.Repositories;

public interface ITagsRepository
{
    Task<IEnumerable<Tag>> GetAllTags();
}