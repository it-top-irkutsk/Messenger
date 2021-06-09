using System;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataBase db = new();
            ServerObj server;
            try
            {
                server = new ServerObj();
                server.Start();
                //Console.WriteLine("sdsd");
                //Task listenTask = new Task(server.Listen);
                //listenTask.Start(); //старт потока прослушивания
                //listenTask.Wait();
            }
            catch (Exception ex)
            {
                //server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
