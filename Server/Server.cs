using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        static TcpListener tcpListener; // сервер для прослушивания
        List<Client> clients = new List<Client>(); // все подключения
        
        
        protected internal void Listen() // прослушка подключений
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    Client netClient = new Client(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(netClient.ProcessServer));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        protected internal void BroadcastMessage(string message)
        {
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                for (int i = 0; i < clients.Count; i++)
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных всем клиентам
                }
            }
        }
        
        protected internal void BroadcastMessageToRoom(string message,int idChat)
        {
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].idChat != idChat)
                    {
                        clients[i].Stream.Write(data, 0, data.Length); //передача данных клиентам
                    }
                    
                }
            }
        }
        protected internal void AddConnection(Client clientObject) // добавление нового подключения к Листу
        {
            clients.Add(clientObject);
        }
        
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            Client client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }
        
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера
 
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}