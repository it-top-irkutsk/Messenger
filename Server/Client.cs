using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using Message_Types;
using Authorization = Message_Types.Authorization;

namespace Server
{
    public class Client
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream {get; private set;}
        public int idChat;
        private TcpClient client;
        private Server server;

        public Client(TcpClient tcpClient, Server netServer)
        {
            idChat = '1';
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = netServer;
            netServer.AddConnection(this);
        }
        public void ProcessServer()
        {
            Authorization validation = new Authorization(false);
            try
            {
                Stream = client.GetStream();
                do
                {
                    string message = GetMessage();
                    Authorization login = JsonSerializer.Deserialize<Authorization>(message);
                    
                    validation.Validation = Login(login);
                    SendMessage(JsonSerializer.Serialize(validation));
                } while (!validation.Validation);
                

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
                string textJSON = GetMessage();
                Msg message = JsonSerializer.Deserialize<Msg>(textJSON);
                switch (message.Type)
                {
                    case TypesMsg.Connection: //TODO Написать проверку логина и пароля полученного от клиента
                        idChat = message.idChat;
                        
                        
                        break;
                    case TypesMsg.Disconnection:
                        server.RemoveConnection(Id);
                        break;
                    case TypesMsg.Text:
                        server.BroadcastMessageToRoom(message.Message,idChat);
                        break;
                    default:
                        break;
                }
            }
        }

        private bool Login(Authorization Login)
        {
            var login = Login.Login;
            var pass = Login.Password; //Todo написать проверку логина и пароля
            return true;
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
        public  void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            Stream.Write(data, 0, data.Length);
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