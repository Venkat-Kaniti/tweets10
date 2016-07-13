using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Tweets10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
		            .UseUrls("http://0.0.0.0:3000")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
