using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using N5.System.Infraestructure;

public static class StartupExtensions
{
    public static IApplicationBuilder InitializeBD(this IApplicationBuilder builder)
    {
        InitializeData(builder.ApplicationServices);
        return builder;
    }

    private static void InitializeData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Entities>();
        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }
}
