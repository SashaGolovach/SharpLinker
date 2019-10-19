using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthentificationServer.Models
{
    public class GithubClientParameters
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public GithubClientParameters(IConfiguration config)
        {
            var section = config.GetSection("GithubClient");
            ClientId = section.GetValue<string>("ClientId");
            ClientSecret = section.GetValue<string>("ClientSecret");
        }
    }
}
