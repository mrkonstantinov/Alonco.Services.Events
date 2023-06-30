using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class CategoryContextSeed
{
    public static void SeedData(IMongoCollection<EventCategory> brandCollection)
    {
        bool checkBrands = brandCollection.Find(b => true).Any();
        string path = Path.Combine("Data", "SeedData", "categories.json");
        if (!checkBrands)
        {
            var brandsData = File.ReadAllText(path);
            var brands = JsonSerializer.Deserialize<List<EventCategory>>(brandsData);
            if (brands != null)
            {
                foreach (var item in brands)
                {
                    brandCollection.InsertOneAsync(item);
                }
            }
        }
    } 
}