using Web.Scraping.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

var app = builder.Build();

app.AddApplicationConfiguration();

await app.RunAsync();
