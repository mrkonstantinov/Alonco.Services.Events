using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface ITagsRepository
{
    Task<IEnumerable<Tag>> GetAllTags();
}