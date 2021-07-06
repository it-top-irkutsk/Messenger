using System;
using System.Threading;


namespace Server
{
    class Program
    {
        static Server server; // сервер

        static void Main(string[] args)
        {
            try
            {
                server = new Server();
                server.Listen();
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
