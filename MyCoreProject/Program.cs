using System;//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;//
using Microsoft.AspNetCore.Hosting;//
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;//



using MyCoreProject.Models;

namespace MyCoreProject
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //BuildWebHost(args).Run();//дефолт
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())//генерация локалбд
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TestContext>();
                    SampleData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                //.UseUrls("http://192.168.1.9:5000", "https://localhost:50001")
                .UseUrls("http://192.168.1.9:5001", "https://localhost:50001")
                .UseKestrel(options =>
                {
                    options.Limits.MaxConcurrentConnections = 100;
                    options.Limits.MaxRequestBodySize = 10 * 1024;
                    options.Limits.MinRequestBodyDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    options.Limits.MinResponseDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    //options.Listen(IPAddress.Loopback, 5000);

                })
            
                //.ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Trace))//для отладочной инфо
                .Build();


    }
}
