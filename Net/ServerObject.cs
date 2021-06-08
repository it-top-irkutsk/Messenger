using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Net {
    public class ServerObject
    {
        static TcpListener tcpListener; // объект для прослушивания
        protected internal List<ClientObject> clients = new List<ClientObject>(); // все клиенты
        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }
        protected internal void RemoveConnection(int id)
        {
            try
            {
                if (clients.ElementAt(id) == null)
                    throw new Exception("Соединения с таким id не существует");
                else
                    clients.RemoveAt(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // прослушивание входящих подключений
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ServerObject server = new ServerObject();
                    ClientObject clientObject = new ClientObject(tcpClient, server);
                    Task clientTask = new(clientObject.Process);
                    clientTask.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }
        //отправка сообщения всем клиентам
        protected internal void BroadcastMessage(string message, int thisId)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++) {
                if (clients[i].Id != thisId) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }
        // отключение всех клиентов
        public void Disconnect()
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
