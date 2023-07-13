using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventCatalog.Core.Entities;

public class Event : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
    public IEnumerable<Tag> Tags { get; set; }

}
