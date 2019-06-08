using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {    
        static void Main(string[] args)
        {
            TCP server = new TCP();
            server.SendResult();
        }        
    }
}
