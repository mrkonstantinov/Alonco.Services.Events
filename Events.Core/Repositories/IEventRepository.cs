using Events.Core.Entities;

namespace Events.Core.Repositories;

public interface IEventRepository
{
    //Task<Pagination<event>> Getevents(eventSpecParams eventsSpecParams);
    Task<Event> GetEvent(string id);
    Task<Event> CreateEvent(Event @event);
    Task<bool> UpdateEvent(Event @event);
    Task<bool> DeleteEvent(string id);
}