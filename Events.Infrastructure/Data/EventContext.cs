using Events.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Events.Infrastructure.Data;

public class EventContext : IEventContext
{
    public IMongoCollection<Event> Events { get; }
    public IMongoCollection<Core.Entities.Tag> Tags { get; }

    public EventContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Tags = database.GetCollection<Core.Entities.Tag>(
            configuration.GetValue<string>("DatabaseSettings:TagsCollection"));
        Events = database.GetCollection<Event>(
            configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        
        TagContextSeed.SeedData(Tags);
        //EventContextSeed.SeedData(Events);
    }
}