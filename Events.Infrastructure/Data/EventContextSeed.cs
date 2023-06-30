using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public class EventContextSeed
{
    public static void SeedData(IMongoCollection<Event> productCollection)
    {
        bool checkProducts = productCollection.Find(b => true).Any();
        string path = Path.Combine("Data", "SeedData", "events.json");
        if (!checkProducts)
        {
            var productsData = File.ReadAllText(path);
            var products = JsonSerializer.Deserialize<List<Event>>(productsData);
            if (products != null)
            {
                foreach (var item in products)
                {
                    productCollection.InsertOneAsync(item);
                }
            }
        }
    }
}