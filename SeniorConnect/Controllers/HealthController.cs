using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Database;

namespace SeniorConnect.Controllers
{
    [ApiController]
    [Route("Health/v1")]
    [AllowAnonymous]
    public class HealthController : BaseController
    {
        public HealthController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        [HttpGet("WebsiteHealth")]
        public async Task<IActionResult> WebsiteHealth()
        {
            return Ok("OK");
        }

        [HttpGet("DatabaseHealth")]
        public async Task<IActionResult> DatabaseHealth()
        {
            _ = await ApplicationContext.Assinaturas.CountAsync();
            return Ok("Ok");
        }
    }
}
