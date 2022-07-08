using Serilog;
using Web.Scraping.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day));


builder.Services
    .AddCoreServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.AddApplicationConfiguration();

await app.RunAsync();
