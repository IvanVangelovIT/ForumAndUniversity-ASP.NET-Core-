using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTechniques
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.AddFilter((provider, category, logLevel) =>
                    {
                        if (provider.Contains("ConsoleLoggerProvider")
                            && category.Contains("Controller")
                            && logLevel >= LogLevel.Information)
                        {
                            return true;
                        }
                        else if (provider.Contains("ConsoleLoggerProvider")
                            && category.Contains("Microsoft")
                            && logLevel >= LogLevel.Information)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });
                });
    }
}
