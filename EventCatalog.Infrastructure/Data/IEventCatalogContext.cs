using EventCatalog.Core.Entities;
using MongoDB.Driver;

namespace EventCatalog.Infrastructure.Data;

public interface IEventCatalogContext
{
    IMongoCollection<Event> Events { get; }
    IMongoCollection<EventCatalog.Core.Entities.Tag> Tags { get; }
}