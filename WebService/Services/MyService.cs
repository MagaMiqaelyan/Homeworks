using System;

namespace Services
{
    public class MyService : IContract
    {
        public string GetMessage(string msg)
        {
            Console.WriteLine(DateTime.Now.ToString() + " " + msg);
            return "The service greets you: " + msg;
        }
    }
}
