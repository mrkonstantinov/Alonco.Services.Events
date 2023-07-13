using EventCatalog.Application.Handlers;
using EventCatalog.Infrastructure.Data;
using EventCatalog.Core.Repositories;
using EventCatalog.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;


namespace EventCatalog.API;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApiVersioning();
        services.AddControllers();

        var t = Configuration["DatabaseSettings:ConnectionString"];

        services.AddHealthChecks()
            .AddMongoDb(Configuration["DatabaseSettings:ConnectionString"], "EventCatalog  Mongo Db Health Check",
                HealthStatus.Degraded);
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventCatalog.API", Version = "v1" }); });

        //DI
        services.AddAutoMapper(typeof(Startup));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateEventHandler).GetTypeInfo().Assembly));

        services.AddScoped<IEventCatalogContext, EventCatalogContext>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITagsRepository, EventRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventCatalog.API v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();        
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }

}