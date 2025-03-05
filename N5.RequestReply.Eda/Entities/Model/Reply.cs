using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using N5.RequestReply.Eda.Entities.Interfaces;

namespace N5.RequestReply.Eda.Entities.Model;

public class Reply : IReply
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string EventId { get; set; }

    public string Topic { get; set; }

    public string Payload { get; set; }

    public DateTime DateCreate { get; set; }
}
