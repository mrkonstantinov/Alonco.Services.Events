using System.Text.Json;
using Events.Core.Entities;
using MongoDB.Driver;

namespace Events.Infrastructure.Data;

public class EventContextSeed
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