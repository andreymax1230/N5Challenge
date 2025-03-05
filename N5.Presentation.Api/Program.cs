using Microsoft.EntityFrameworkCore;
using N5.System.Infraestructure;
using Serilog;
using Serilog.Exceptions;
using N5.Presentation.Api.Infraestructure;
using N5.System.Application;
using System.Reflection;
using N5.Kafka.Eda;
using N5.RequestReply.Eda;
using N5.System.Integrator;

namespace N5.Presentation.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var logger = new LoggerConfiguration()
        .MinimumLevel.Verbose()
             .Enrich.WithProperty("ApplicationContext", "N5.Presentation.Api")
             .Enrich.WithExceptionDetails()
             .Enrich.FromLogContext()
             .WriteTo.Console();
        try
        {
            builder.Services.AddDbContext<Entities>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Entities"));
            });
            var entryAssembly = Assembly.GetEntryAssembly();
            // add services dependencies
            builder.Services.AddApplication();
            builder.Services.AddIntegrator();
            builder.Services.AddCustomServices(builder.Configuration);
            builder.Services.InitializeKafkaServices(builder.Configuration, assemblies: entryAssembly!);
            builder.Services.AddDependecyInjectionRequestReply(builder.Configuration);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseHostKafka();
            app.InitializeBD();
            app.Run();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}