#define Snippet1
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ASPTechniquesRazor
{
#if Snippet1
    #region

    //Test
    #endregion
#endif
    public class Program
    {
        private IHost _host;
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hostsettings.json", optional: true)
            .AddCommandLine(args)
            .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });

            //WebHost.CreateDefaultBuilder(args)
            //    .ConfigureLogging(logging =>
            //    {
            //        logging.SetMinimumLevel(LogLevel.Warning);
            //    })
            //    .ConfigureKestrel((context, options) =>
            //    {
            //        options.Limits.MaxRequestBodySize = 20000000;
            //    })
            //    .UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
            //    .UseStartup<Startup>();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
        //            webBuilder.UseSetting(WebHostDefaults.ShutdownTimeoutKey, "true");
        //            webBuilder.CaptureStartupErrors(true);
        //            //webBuilder.UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002");
        //            webBuilder.UseStartup<Startup>();
        //            webBuilder.UseShutdownTimeout(TimeSpan.FromSeconds(20));
        //        })
        //        .ConfigureAppConfiguration((hostingContext, config) =>
        //        {
        //            config.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
        //        });

        public async Task StopAsync()
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }




        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        // Host.CreateDefaultBuilder(args)
        //  .ConfigureHostConfiguration(configHost =>
        //  {
        //      configHost.SetBasePath(Directory.GetCurrentDirectory());
        //      configHost.AddJsonFile("hostsettings.json", optional: true);
        //      configHost.AddEnvironmentVariables(prefix: "PREFIX_");
        //      configHost.AddCommandLine(args);
        //  });
    }
    internal class LifetimeEventsHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;

        public LifetimeEventsHostedService(
            ILogger<LifetimeEventsHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");

            // Perform post-startup activities here
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");

            // Perform on-stopping activities here
        }

        private void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");

            // Perform post-stopped activities here
        }
    }
}
