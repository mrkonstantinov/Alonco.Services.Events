using EventCatalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EventCatalog.Infrastructure.Data;

public class EventCatalogContext : IEventCatalogContext
{
    public IMongoCollection<Event> Events { get; }
    public IMongoCollection<EventCatalog.Core.Entities.Tag> Tags { get; }

    public EventCatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Tags = database.GetCollection<EventCatalog.Core.Entities.Tag>(
            configuration.GetValue<string>("DatabaseSettings:TagsCollection"));
        Events = database.GetCollection<Event>(
            configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        
        TagContextSeed.SeedData(Tags);
        //EventContextSeed.SeedData(Events);
    }
}