using MongoDB.Driver;
using N5.RequestReply.Eda.Entities.Model;

namespace N5.RequestReply.Eda.Persistence.Context;

public class RequestReplyContextDB
{
    public readonly IMongoCollection<Producer> producer;
    public readonly IMongoCollection<Reply> reply;
    readonly IMongoDatabase database;

    public RequestReplyContextDB(IMongoClient client)
    {
        database = client.GetDatabase("RequestReply");
        reply = database.GetCollection<Reply>("Reply");
        producer = database.GetCollection<Producer>("Producer");
    }
}
