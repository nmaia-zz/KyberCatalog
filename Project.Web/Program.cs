using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Project.Repository.Data;

namespace Project.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            DbInitializer.Initialize();

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}
