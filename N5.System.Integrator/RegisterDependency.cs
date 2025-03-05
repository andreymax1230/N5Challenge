using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace N5.System.Integrator;
public static class RegisterDependency
{
    public static IServiceCollection AddIntegrator(this IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
