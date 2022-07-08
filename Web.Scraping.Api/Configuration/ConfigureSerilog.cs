using Serilog;

namespace Web.Scraping.Api.Configuration;

public static class ConfigureSerilog
{
    public static ConfigureHostBuilder AddSerilog(this ConfigureHostBuilder host)
    {
        host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day));
        
        return host;
    }
}