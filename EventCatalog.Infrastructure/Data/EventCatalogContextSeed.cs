using System.Text.Json;
using EventCatalog.Core.Entities;
using MongoDB.Driver;

namespace EventCatalog.Infrastructure.Data;

public class EventCatalogContextSeed
{
    public static void SeedData(IMongoCollection<Event> eventCollection)
    {
        bool checkEvents = eventCollection.Find(b => true).Any();
        string path = Path.Combine("bin", "Debug", "net7.0", "Data", "SeedData", "events.json");
        if (!checkEvents)
        {
            var eventsData = File.ReadAllText(path);
            var events = JsonSerializer.Deserialize<List<Event>>(eventsData);
            if (events != null)
            {
                foreach (var item in events)
                {
                    eventCollection.InsertOneAsync(item);
                }
            }
        }
    }
}