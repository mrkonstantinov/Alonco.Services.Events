﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class EventCategory : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
    public EventCategory Parent { get; set; }
}
