using AuthentificationServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuthentificationServer.Controllers
{
    public class AuthorizeBaseController : ControllerBase
    {
        public GithubClientParameters _githubClientParameters { get; }

        public AuthorizeBaseController(GithubClientParameters githubClientParameters)
        {
            _githubClientParameters = githubClientParameters;
        }

        public virtual async Task<string> GetAuthorizationUrlAsync(string socketId)
        {
            var client = new GitHubClient(new ProductHeaderValue(AppConstants.ProductHeaderValue));

            var request = new OauthLoginRequest(_githubClientParameters.ClientId)
            {
                Scopes = { "user", "notifications" },
                State = socketId
            };

            var oauthLoginUrl = client.Oauth.GetGitHubLoginUrl(request);
            return oauthLoginUrl.ToString();
        }

        public virtual async Task AuthorizeAsync(string code, string state)
        {
            string host = "127.0.0.1";
            int port = 9999;
            var client = new TcpClient();
            client.Connect(host, port);
            NetworkStream stream = client.GetStream();
            try
            {
                var msgData = new RegisterTokenModel
                {
                    Secret = "secret",
                    ClientId = state,
                    Code = code
                };
                var message = new Message
                {
                    Action = "RegisterToken",
                    Data = JsonConvert.SerializeObject(msgData)
                };
                byte[] data = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(message));
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stream.Close();
                client.Close();
            }

        }
    }
}
