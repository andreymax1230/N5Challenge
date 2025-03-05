using Microsoft.AspNetCore.Hosting;
using N5.System.Domain.Repositories;
using N5.System.Domain.UnitOfWork;
using N5.System.Infraestructure;

namespace N5.Presentation.Api.Infraestructure;

public static class RegisterDependency
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        return services;
    }
}