using System;
using MyClient.ServiceReferenceTCP;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {            
            string greeting = Console.ReadLine();
            ContractClient contract = new ContractClient();
            Console.WriteLine(contract.GetMessage(greeting));
        }
    }
}
