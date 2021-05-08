using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace OneSignal
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        static void Main(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            // .AddJsonFile("config.json", optional: false, reloadOnChange: true);
            //Configuration = builder.Build();
            //var config = new Config();
            //Configuration.GetSection("Config").Bind(config);
            //var services = new ServiceCollection();
            //var provider = services.BuildServiceProvider();
        }
    }
}
