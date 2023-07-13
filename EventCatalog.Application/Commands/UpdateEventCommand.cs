using EventCatalog.Core.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventCatalog.Application.Commands;

public class UpdateEventCommand : IRequest<bool>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
   
}