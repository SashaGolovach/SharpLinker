using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthentificationServer.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<string> Get()
        {
            return "some value";
        }
    }
}