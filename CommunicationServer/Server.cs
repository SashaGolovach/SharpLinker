using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationServer
{
    public class Server
    {
        const string clientId = "f5ec87b5a37e53844203";
        const string clientSecret = "6434ef1a4525c53ac855a1b2e1af02e45d286229";
        static TcpListener tcpListener;
        List<Client> clients = new List<Client>();

        protected internal void AddConnection(Client Client)
        {
            clients.Add(Client);
        }

        protected internal void RemoveConnection(string id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
                clients.Remove(client);
        }

        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 9999);
                tcpListener.Start();
                Console.WriteLine("Server started. Waiting for connections ...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Client client = new Client(tcpClient, this);
                    Thread clientThread = new Thread(async () => await client.Process());
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }



        protected internal void BroadcastMessage(Message message, string id)
        {
            var serializedMessage = JsonConvert.SerializeObject(message);
            byte[] data = Encoding.Unicode.GetBytes(serializedMessage);
            var client = clients.FirstOrDefault(c => c.Id == id);
            if(client != null)
                client.Stream.Write(data, 0, data.Length);
        }

        protected internal bool ValidateSecret(string secret)
        {
            return true;
        }

        protected internal async Task RegisterUserToken(RegisterTokenModel data)
        {
            if (ValidateSecret(data.Secret))
            {
                var githubClient = new GitHubClient(new ProductHeaderValue("sharp-linker"));
                var request = new OauthTokenRequest(clientId, clientSecret, data.Code);
                var token = await githubClient.Oauth.CreateAccessToken(request);
                var response = new Message
                {
                    Action = "Token",
                    Data = token.AccessToken
                };
                BroadcastMessage(response, data.ClientId);
            }
        }

        protected internal void Disconnect()
        {
            tcpListener.Stop(); 

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
            Environment.Exit(0); 
        }
    }
}
