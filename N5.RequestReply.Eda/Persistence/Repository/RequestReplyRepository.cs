using MongoDB.Driver;
using N5.RequestReply.Eda.Entities.Interfaces;
using N5.RequestReply.Eda.Entities.Model;
using N5.RequestReply.Eda.Interface;
using N5.RequestReply.Eda.Persistence.Context;

namespace N5.RequestReply.Eda.Persistence.Repository;

public class RequestReplyRepository(RequestReplyContextDB _context) : IRequestReplayRepository
{
    public Task GenerateRequestReplyAsync(IReply reply) => _context.reply.InsertOneAsync(reply as Reply);

    public Task DeleteReplyAsync(string idEvent) => _context.reply.DeleteManyAsync(x => x.EventId == idEvent);

    public async Task<IReply> GetReplyByIdSessionAsync(string idEvent, string topic) => _context.reply.FindAsync(x => x.EventId == idEvent && x.Topic == topic).Result.FirstOrDefault() as IReply;

    public Task<long> HasReplyByIdSessionAsync(string idEvent, string topic) => Task.Factory.StartNew(() => _context.reply.CountDocuments(x => x.EventId == idEvent && x.Topic == topic));
}
