using Microsoft.AspNetCore.Mvc;

namespace SeniorConnect.Controllers
{
    [ApiController]
    [Route("Token/v1")]
    public class TokenController : Controller
    {
        [HttpGet("CreateToken")]
        public async Task CreateToken(string username, string password)
        {

        }
    }
}
