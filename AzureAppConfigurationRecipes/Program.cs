using System;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace AzureAppConfigurationRecipes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration((hostingContext, config) =>
                   {
                       IConfigurationRoot settings = config.Build();
                       config.AddAzureAppConfiguration(options =>
                       {
                           options.Connect(settings["ConnectionStrings:AppConfig"])
                                  .Watch("Test:Settings:Label", TimeSpan.FromSeconds(5)) // interval optional, default 30s
                                  // Watch a specific setting at an interval but reload all if it changes
                                  //.WatchAndReloadAll("Test:Settings:Label", TimeSpan.FromSeconds(30))
                                  .UseFeatureFlags();
                       });
                   })
                   .UseStartup<Startup>();
    }
}
