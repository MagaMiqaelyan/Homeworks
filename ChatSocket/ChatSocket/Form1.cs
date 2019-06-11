using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ChatSocket
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }

        Socket sck;
        EndPoint epMe;
        EndPoint epFriend;
        byte[] buffer;

        private void Chat_Load(object sender, EventArgs e)
        {
            // Set socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // Get user IP
            textIpMe.Text = GetIp();            
        }

        private string GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // Binding Socket
            epMe = new IPEndPoint(IPAddress.Parse(textIpMe.Text), Convert.ToInt32(textPortMe.Text));
            sck.Bind(epMe);

            // Connecting to friend
            epFriend = new IPEndPoint(IPAddress.Parse(textIpFriend.Text), Convert.ToInt32(textPortFriend.Text));
            sck.Connect(epFriend);

            // Listening the specific port
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epFriend, new AsyncCallback(MessageCallBack), buffer);
        }

        private void MessageCallBack(IAsyncResult ar)
        {
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])ar.AsyncState;

                //Converting byte[] to string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedMessage = aEncoding.GetString(receivedData);

                // Adding this message into MessageBox
                listMessage.Items.Add("Friend : " + receivedMessage);

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epFriend, new AsyncCallback(MessageCallBack), buffer);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            // Converting string message to byte[]
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = aEncoding.GetBytes(textSendMessage.Text);

            // Sending the Encoded message
            sck.Send(sendingMessage);

            // Adding to MessageBox
            listMessage.Items.Add("Me : " + textSendMessage.Text);
            textSendMessage.Text = "";
        }
    }
}
