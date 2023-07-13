using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EventCatalog.Application.Responses;

public class TagResponse
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
}