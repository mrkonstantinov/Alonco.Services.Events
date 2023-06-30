using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IEventRepository
{
    //Task<Pagination<event>> Getevents(eventSpecParams catalogSpecParams);
    Task<Event> GetEvent(string id);
    Task<IEnumerable<Event>> GetEventByName(string name);
    Task<IEnumerable<Event>> GetEventByCategory(string name);
    Task<Event> CreateEvent(Event @event);
    Task<bool> UpdateEvent(Event @event);
    Task<bool> DeleteEvent(string id);
}