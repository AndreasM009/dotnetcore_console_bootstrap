using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            var configuration = configurationBuilder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(new LoggerFactory().AddConsole().AddDebug())
                .AddOptions()
                .Configure<MyConfiguration>(configuration.GetSection("MyConfiguration"))
                .AddSingleton<IEchoService, EchoService>();

            var services = serviceProvider.BuildServiceProvider();
            var echo = services.GetService<IEchoService>();
            echo.Echo();


        }
    }
}
