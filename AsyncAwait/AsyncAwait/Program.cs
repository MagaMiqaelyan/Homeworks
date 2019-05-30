using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        private const string URL = "https://docs.microsoft.com//";
        private static HttpClient httpClient;

        static void Main(string[] args)
        {
            //SyncMethod();
            //DoSomething();
            //AsyncMethod().Wait();
            Task<string> t = Task.Run(() => LongRunningOperation("Continuewith"));
            Console.WriteLine(t.Id);
            t.ContinueWith((t1) =>
            {
                Console.WriteLine(t1.Id);
            });
            Console.WriteLine();
        }
        private static string LongRunningOperation(string s)
        {            
            return s + " Completed";
        }


        private static void DoSomething()
        {
            Console.WriteLine("Do something before async method");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("****");
            }
            Console.WriteLine();
        }

        private async static Task<string> AsyncMethod()
        {
            Console.WriteLine("Starting async method");
            httpClient = new HttpClient();
            string result = await httpClient.GetStringAsync(URL);
            Console.WriteLine($"Result is {result.Length}");
            return result.Length.ToString();
        }
      
        private static void SyncMethod()
        {
            Console.WriteLine("Syncronous task");
        }
    }
}
