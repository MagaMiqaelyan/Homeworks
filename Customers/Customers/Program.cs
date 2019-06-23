using Microsoft.AspNetCore.Hosting;
using System;

namespace Customers
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5050")
                .UseStartup<StartUp>()
                .Build();

            Console.WriteLine("Go to this Url: http://localhost:5050/Service.asmx");
            host.Run();
            
        }
    }
}
