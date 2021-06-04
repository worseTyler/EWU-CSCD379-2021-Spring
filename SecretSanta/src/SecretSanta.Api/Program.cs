using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace SecretSanta.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("test");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
            .CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configHost =>{
                configHost
                    .AddEnvironmentVariables()
                    .AddCommandLine(args);
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
