using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BeersApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                //.UseUrls("http://localhost:5000")
                .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
