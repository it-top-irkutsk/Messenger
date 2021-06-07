using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Client
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream {get; private set;}
        private string userName;
        public int chat;
        private TcpClient client;
        private Server server;

        public Client(TcpClient tcpClient, Server netServer)
        {
            chat = '1';
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = netServer;
            netServer.AddConnection(this);
        }
        public void ProcessServer()
        {
            try
            {
                Stream = client.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                userName = message;
                Console.WriteLine($"{userName} : Подключился к серверу");
                Thread receiveThread = new Thread(new ThreadStart(() => ServerChat()));
                receiveThread.Start(); //старт потока
                while (true)
                {
                    //server.BroadcastMessage("Message");//TODO написать отправку сообщения клиентам если это надо от именни сервера
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }
        
        protected internal void ServerChat() //TODO Написать прием сообщений и отправка клиентам
        {
            while (true)
            {
                string text = GetMessage();
                server.BroadcastMessageToRoom(text,chat);
            }
        }
        
        private string GetMessage()
        {
            try
            {
                byte[] data = new byte[64]; // буфер для получаемых данных
                StringBuilder message = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = Stream.Read(data, 0, data.Length);
                    message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (Stream.DataAvailable);
                return message.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}