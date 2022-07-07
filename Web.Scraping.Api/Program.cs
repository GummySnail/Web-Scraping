using Web.Scraping.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCoreServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.AddApplicationConfiguration();

await app.RunAsync();
