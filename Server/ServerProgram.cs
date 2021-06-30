using System;

namespace ServerApp
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            Server server;
            try
            {
                server = new Server();
                server.Start();

                Console.WriteLine("Нажмите Esc, чтобы остановить сервер.");
                while (Console.ReadKey(true).Key != ConsoleKey.Escape) {}

                server.Stop();
                server.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ServerProgram.Main(): {0}", ex);
            }
        }
    }
}
