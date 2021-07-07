using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerApp
{
    class Server
    {
        public List<ServerClient> clients;
        public bool Listening { get; private set; }
        private TcpListener tcpListener;
        public Server()
        {
            IPEndPoint address = new(IPAddress.Any, 8888);
            tcpListener = new(address);
            clients = new();
        }
        public void Start()
        {
            try
            {
                Listening = true;
                foreach (ServerClient client in clients)
                {
                    client.StartListening();
                }
                tcpListener.Start();
                Task taskServer = Task.Run(() => ListenForClients());

                Console.WriteLine("Сервер запущен. Ожидание подключений.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Server.Start(): {0}", ex);
                Stop();
            }
        }
        private void ListenForClients()
        {
            try
            {
                while (Listening)
                {
                    if (tcpListener.Pending())
                    {
                        ServerClient client = new(tcpListener.AcceptTcpClient(), this);
                        clients.Add(client);
                        StartClient(client);

                        Console.WriteLine("Подключился новый клиент. Клиентов подключено: {0}", clients.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Server.AcceptClients: {0}", ex);
                Stop();
            }
        }
        public void StartClient(ServerClient client)
        {
            client.StartListening();
        }
        public ServerClient GetClientAt(int index)
        {
            try
            {
                return index <= clients.Count && index >= 0 ?
                        clients[index] :
                        null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Server.GetClientAt(): {0}", ex);
                return null;
            }
        }
        public int GetClientsCount()
        {
            try
            {
                return clients.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Server.GetClientsCount(): {0}", ex);
                return 0;
            }
        }
        public void CloseClient(ServerClient client)
        {
            if (clients.Contains(client)) clients.Remove(client);
            if (client.Connected) client.Close();
        }
        public void Stop()
        {
            if (Listening)
            {
                Listening = false;
                foreach (ServerClient client in clients)
                {
                    client.StopListening();
                }
                tcpListener.Stop();

                Console.WriteLine("Сервер приостановлен.");
            }
        }
        public void Close()
        {
            Console.WriteLine("Закрытие сервера.");
            Stop();
            for (int index = 0; index < clients.Count; index++)
            {
                CloseClient(GetClientAt(index));
            }
        }
    }
}
