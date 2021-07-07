using System;
using ServerApp;
using System.Net;

namespace ClientApp
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            try
            {
                Client client = new();
                client.Connect(new(IPAddress.Parse("127.0.0.1"), 8888));
                client.StartListening();
                for (int i = 0; i < 1000; i++)
                {
                    client.SendMessage("Клиент 1: " + i + "\n");
                }
                //client.SendMessage();
                Console.WriteLine("Нажмите Esc, чтобы остановить клиент.");
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }
                //client.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ClientProgram.Main(): {0}", ex);
            }
        }
    }
}
