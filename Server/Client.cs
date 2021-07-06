using System;
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
        private Logger.Logger log;
        public Authorization login;
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream {get; private set;}
        private TcpClient client;
        private Server server;

        public Client(TcpClient tcpClient, Server netServer)
        {
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
                    login = JsonSerializer.Deserialize<Authorization>(message);
                    validation.Validation = Login(login);
                    if (validation.Validation == false)
                    {
                        log.Warning($"Неверный пароль или логин при Авторизации Логин:{login.Login} Пароль:{login.Password}");
                    }
                    SendMessage(JsonSerializer.Serialize(validation));
                } while (!validation.Validation);
                Console.WriteLine($"К серверу подключился пользователь - {login.Login}");
                log.Info($"К серверу подключился пользователь - {login.Login}");

                ServerChat();
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
                try
                {
                    string textJSON = GetMessage();
                    Msg message = JsonSerializer.Deserialize<Msg>(textJSON);
                    if (message != null)
                    {
                        switch (message.Type)
                        {
                            case TypesMsg.Connection:

                                break;
                            case TypesMsg.Disconnection:
                                Disconnection(message);
                                break;
                            case TypesMsg.Text:
                                Message(message);
                                break;
                            default:
                                Console.WriteLine($"Пользователь {login.Login} отправил не тот тип сообщения");
                                log.Info($"Пользователь {login.Login} отправил не тот тип сообщения");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Message пустой пришол от пользователя {login.Login}");
                        log.Info($"Message пустой пришол от пользователя {login.Login}");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Ошибка принятого сообщения {e.Message} от пользователя {login.Login}");
                    log.Warning($"Ошибка принятого сообщения {e.Message} от пользователя {login.Login}");
                }
            }
        }

        private bool Login(Authorization Login)
        {
            var login = Login.Login;
            var pass = Login.Password; //Todo написать проверку логина и пароля
            return true;
        }

        private void Disconnection(Msg message)
        {
            login.Validation = false;
            string textExport = JsonSerializer.Serialize(message); //отправка остальным что пользователь отключился
            server.BroadcastMessage(textExport);
            log.Info($"От сервера Отключился пользователь - {login.Login}");
            server.RemoveConnection(Id); //удаление соединения с пользователем
        }

        private void Message(Msg message)
        {
            string textExport = JsonSerializer.Serialize(message);
            server.BroadcastMessage(textExport);
            log.Info($"Пользователь отправил сообщение - {login.Login} Текст:{message.Message}");
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
                log.Warning($"Ошибка при приеме сообщения :{e.Message}");
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