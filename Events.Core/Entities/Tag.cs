using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Events.Core.Entities;

public class Tag : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
}