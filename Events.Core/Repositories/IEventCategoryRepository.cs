using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IEventCategoryRepository
{
    Task<IEnumerable<EventCategory>> GetAllCategories();
}