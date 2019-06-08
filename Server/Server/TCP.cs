using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class TCP : INetworkService
    {
        int PORT_NO = 500;
        string SERVER_IP = "127.0.0.1";

        public void SendResult()
        {
            MathService mathService = new MathService();

            // Listen at the specified IP and port no.
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            // Incoming client connected.
            TcpClient client = listener.AcceptTcpClient();

            // Get the incoming data through a network stream.
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            // Read incoming stream.
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            // Convert the data received into a string.
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received : {0}", dataReceived);

            // Do math operations
            string[] rec = dataReceived.Split(':');
            double result = 0.0;
            switch (dataReceived[0])
            {
                case '+':
                    result = mathService.Add(Convert.ToDouble(rec[1]), Convert.ToDouble(rec[2]));
                    break;
                case '-':
                    result = mathService.Sub(Convert.ToDouble(rec[1]), Convert.ToDouble(rec[2]));
                    break;
                case '*':
                    result = mathService.Mult(Convert.ToDouble(rec[1]), Convert.ToDouble(rec[2]));
                    break;
                case '/':
                    result = mathService.Div(Convert.ToDouble(rec[1]), Convert.ToDouble(rec[2]));
                    break;
                default:
                    break;
            }

            // Write back the result to the client.
            Console.WriteLine("Sending back : {0}", result);
            byte[] sending = ASCIIEncoding.ASCII.GetBytes(result.ToString());
            nwStream.Write(sending, 0, sending.Length);
            client.Close();
            listener.Stop();
        }
    }
}
