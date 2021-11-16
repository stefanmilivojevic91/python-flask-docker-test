using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(WithApplicationConfiguration)
                .ConfigureWebHostDefaults(WithApplicationWebHostDefaults);

        private static void WithApplicationConfiguration(HostBuilderContext hostContext, IConfigurationBuilder configuration)
        {
            var environment = hostContext.HostingEnvironment;

            configuration.SetBasePath(environment.ContentRootPath);
            configuration.AddJsonFile("configuration.application.json", false, true);
            configuration.AddJsonFile($"configuration.application.{environment.EnvironmentName}.json", true, true);

            if(environment.IsDevelopment())
            {
                configuration.AddUserSecrets(Assembly.GetExecutingAssembly());
            }

            configuration.AddEnvironmentVariables();
        }

        private static void WithApplicationWebHostDefaults(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>();
        }
    }
}
