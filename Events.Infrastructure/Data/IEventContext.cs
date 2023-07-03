using Events.Core.Entities;
using MongoDB.Driver;

namespace Events.Infrastructure.Data;

public interface IEventContext
{
    IMongoCollection<Event> Events { get; }
    IMongoCollection<Core.Entities.Tag> Tags { get; }
}