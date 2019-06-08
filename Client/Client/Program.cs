namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TCP client = new TCP();
            client.SendMessage();
        }
    }
}
