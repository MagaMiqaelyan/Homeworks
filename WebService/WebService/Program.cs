using Services;
using System;
using System.ServiceModel;


namespace WebService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MyService));
            host.Open();
            Console.WriteLine("Service started");
            Console.ReadKey();
            host.Close();
        }
    }
}
