using System;
using System.Net.Sockets;

namespace ServerApp
{
    class ServerClient : Client
    {
        private Server server;
        public ServerClient() : base() {}
        public ServerClient(TcpClient clientRef, Server serverRef) : base(clientRef)
        {
            server = serverRef;
            Connected = true;
        }
        public override void Close()
        {
            try
            {
                StopListening();
                networkStream?.Close();
                tcpClient?.Close();
                if (server.clients.Contains(this)) server.CloseClient(this);
                Connected = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ServerClient.Close(): {0}", ex);
            }
        }
    }
}
