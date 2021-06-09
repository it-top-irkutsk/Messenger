using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class ServerObj
    {
        private TcpListener server; // сервер
        private List<TcpClient> clients; // все клиенты
        public ServerObj()
        {
            server = new(IPAddress.Any, 8888);
            clients = new();
        }
        public void Start()
        {
            try
            {
                server.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);
                    Console.WriteLine("Подключился новый клиент.");

                    Task clientTask = new(() => ClientProcess(client));
                    clientTask.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Stop();
            }
        }
        private void ClientProcess(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];

            //string message = "aaaaaaaaaaaaaaa";
            //byte[] data = Encoding.Unicode.GetBytes(message);
            //stream.Write(data, 0, data.Length);

            stream.Read(data, 0 , data.Length);
            String mstring = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
            Console.WriteLine(mstring);
        }

        private void Stop()
        {
            server.Stop(); //остановка сервера
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}
