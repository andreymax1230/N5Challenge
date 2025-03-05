using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5.Kafka.Eda.Interface;
using N5.Kafka.Eda.Services;
using N5.RequestReply.Eda.Interface;
using N5.RequestReply.Eda.Persistence.Context;
using N5.RequestReply.Eda.Persistence.Repository;
using N5.RequestReply.Eda.Service;

namespace N5.RequestReply.Eda;

public static class StartupRequestReplyExtensions
{
    public static IServiceCollection AddDependecyInjectionRequestReply(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddTransient<IRequestReplayRepository, RequestReplyRepository>();
        services.AddTransient<IRequestReplayService, RequestReplyService>();
        services.AddSingleton<RequestReplyContextDB>();
        return services;
    }
}
