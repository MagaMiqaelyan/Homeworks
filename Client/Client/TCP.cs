﻿using System;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class TCP : INetworkService
    {
        int PORT_NO = 500;
        string SERVER_IP = "127.0.0.1"; 

        public void SendMessage()
        {
            // Data to send to the server
            Console.Write("Please enter the expression\t");
            string textToSend = Console.ReadLine();

            // Create a TCPClient object at the IP and port no.
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            // Send the text
            Console.WriteLine("Sending {0}", textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            // Read back the text
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            nwStream.Close();
            client.Close();
        }
    }
}
