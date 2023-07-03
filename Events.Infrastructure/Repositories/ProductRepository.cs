using Events.Core.Entities;
using Events.Core.Repositories;
using Events.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Events.Infrastructure.Repositories;

public class EventRepository : IEventRepository, ITagsRepository
{
    private readonly IEventContext _context;

    public EventRepository(IEventContext context)
    {
        _context = context;
    }    

    public async Task<Event> GetEvent(string id)
    {
        return await _context
            .Events
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }    

    public async Task<Event> CreateEvent(Event @event)
    {
        await _context.Events.InsertOneAsync(@event);
        return @event;
    }

    public async Task<bool> UpdateEvent(Event @event)
    {
        var updateResult = await _context
            .Events
            .ReplaceOneAsync(p => p.Id == @event.Id, @event);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteEvent(string id)
    {
        FilterDefinition<Event> filter = Builders<Event>.Filter.Eq(p => p.Id, id);
        DeleteResult deleteResult = await _context
            .Events
            .DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<Core.Entities.Tag>> GetAllTags()
    {
        return await _context
            .Tags
            .Find(b => true)
            .ToListAsync();
    }
}