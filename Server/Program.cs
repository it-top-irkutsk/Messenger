using System;
using System.Threading.Tasks;
using DB_Connection;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new();
            ServerObject server = new();
            try
            {
                server = new ServerObject();
                //Console.WriteLine("sdsd");
                Task listenTask = new Task(server.Listen);
                listenTask.Start(); //старт потока прослушивания
                listenTask.Wait();
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
