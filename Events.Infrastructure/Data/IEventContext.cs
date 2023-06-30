using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface IEventContext
{
    IMongoCollection<Event> Events { get; }
    IMongoCollection<Core.Entities.Tag> Tags { get; }
}