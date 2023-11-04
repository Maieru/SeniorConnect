using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Database;

namespace SeniorConnect.Controllers
{
    [ApiController]
    [Route("Health/v1")]
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
            try
            {
                var numeroAssinaturas = await ApplicationContext.Assinaturas.CountAsync();
                return Ok("Ok");
            }
            catch
            {
                return Ok("Sem acesso ao banco de dados");
            }
        }
    }
}
