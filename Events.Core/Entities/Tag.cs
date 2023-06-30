using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Tag
{
    [BsonElement("Name")]
    public string Name { get; set; }
}