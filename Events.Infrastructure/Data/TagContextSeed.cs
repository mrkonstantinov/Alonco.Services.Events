using System.Text.Json;
using Events.Core.Entities;
using MongoDB.Driver;

namespace Events.Infrastructure.Data;

public class TagContextSeed
{
    public static void SeedData(IMongoCollection<Core.Entities.Tag> typeCollection)
    {
        bool checkTypes = typeCollection.Find(b => true).Any();
        string path = Path.Combine("bin", "Debug", "net7.0", "Data", "SeedData", "tags.json");
        if (!checkTypes)
        {
            var typesData = File.ReadAllText(path);
            var types = JsonSerializer.Deserialize<List<Core.Entities.Tag>>(typesData);
            if (types != null)
            {
                foreach (var item in types)
                {
                    typeCollection.InsertOneAsync(item);
                }
            }
        }
    }
}