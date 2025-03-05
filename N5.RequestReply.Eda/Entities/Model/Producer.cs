using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using N5.RequestReply.Eda.Entities.Interfaces;

namespace N5.RequestReply.Eda.Entities.Model;

public class Producer : IProducer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string EventId { get; set; }

    public string Topic { get; set; }
}
