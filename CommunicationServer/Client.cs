using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServer
{
    public class Client
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        Server server;

        public Client(TcpClient tcpClient, Server serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public async Task Process()
        {
            try
            {
                Stream = client.GetStream();
                string messageStr = GetMessage();
                var message = JsonConvert.DeserializeObject<Message>(messageStr);
                switch (message.Action)
                {
                    case "GetClientId":
                        var response = new Message
                        {
                            Action = "Id",
                            Data = Id
                        };
                        server.BroadcastMessage(response, Id);
                        break;
                    case "RegisterToken":
                        var data = JsonConvert.DeserializeObject<RegisterTokenModel>(message.Data);
                        await server.RegisterUserToken(data);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64]; 
            StringBuilder builder = new StringBuilder();
            int bytes;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
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
