using N5.RequestReply.Eda.Entities.Interfaces;

namespace N5.RequestReply.Eda.Interface;

public interface IRequestReplayRepository
{
    Task GenerateRequestReplyAsync(IReply reply);

    Task<IReply> GetReplyByIdSessionAsync(string idSession, string topic);

    Task<long> HasReplyByIdSessionAsync(string idSession, string topic);

    Task DeleteReplyAsync(string idEvent);
}
