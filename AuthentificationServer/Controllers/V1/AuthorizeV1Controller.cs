using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthentificationServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthentificationServer.Controllers
{
    [Route("api/oauth")]
    [ApiController]
    public class AuthorizeV1Controller : AuthorizeBaseController
    {

        public AuthorizeV1Controller(GithubClientParameters githubClientParameters) 
            : base(githubClientParameters)
        {
        }

        [HttpGet]
        [Route("url")]
        public override async Task<string> GetAuthorizationUrlAsync(string socketId)
        {
            return await base.GetAuthorizationUrlAsync(socketId);
        }

        [HttpGet]
        [Route("authorize")]
        public override async Task AuthorizeAsync(string code, string state)
        {
            await base.AuthorizeAsync(code, state);
        }
    }
}
