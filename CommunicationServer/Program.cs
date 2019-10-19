using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommunicationServer
{
    class Program
    {
        static Server server;
        static Thread listenThread;

        static void Main(string[] args)
        {
            try
            {
                server = new Server();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
