using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerApp
{
    public class Client
    {
        protected TcpClient tcpClient;
        protected NetworkStream networkStream;
        protected string message;
        protected StringBuilder stringBuilder;
        protected int dataLength;
        protected byte[] data;

        public bool Listening { get; protected set; }
        public bool Connected { get; protected set; }
        public Client()
        {
            tcpClient = new TcpClient();
            Init();
        }
        public Client(TcpClient clientRef)
        {
            tcpClient = clientRef;
            networkStream = tcpClient.GetStream();
            Init();
        }
        private void Init()
        {
            stringBuilder = new StringBuilder();
            data = new byte[64];
        }
        public void Connect(IPEndPoint address)
        {
            try
            {
                tcpClient.Connect(address);
                networkStream = tcpClient.GetStream();
                Connected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.Connect(): {0}", ex);
            }
        }
        public void StartListening()
        {
            try
            {
                Listening = true;
                Task clientTask = Task.Run(() => ListenForMessages());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.Start(): {0}", ex);
            }
        }
        public void ListenForMessages()
        {
            try
            {
                while (Listening)
                {
                    GetMessage();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.ListenForMessages(): {0}", ex);
            }
        }
        public void GetMessage()
        {
            try
            {
                while (networkStream.DataAvailable)
                {

                    dataLength = networkStream.Read(data, 0, data.Length);
                    stringBuilder.Append(Encoding.Unicode.GetString(data, 0, dataLength));
                }
                if (stringBuilder.Length != 0)
                {
                    message = stringBuilder.ToString();
                    Console.WriteLine(message);
                    stringBuilder.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.GetMessage(): {0}", ex);
            }
        }
        public void SendMessage(string message)
        {
            try
            {
                data = Encoding.Unicode.GetBytes(message);
                dataLength = data.Length;
                networkStream.Write(data, 0, dataLength);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.SendMessage(): {0}", ex);
            }
        }
        public void StopListening()
        {
            try
            {
                Listening = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.Stop(): {0}", ex);
            }
        }
        public virtual void Close()
        {
            try
            {
                StopListening();
                networkStream?.Close();
                tcpClient?.Close();
                Connected = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Client.Close(): {0}", ex);
            }
        }
    }
}
