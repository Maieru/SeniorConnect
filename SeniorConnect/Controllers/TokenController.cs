using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Repository.Usuario;
using Negocio.TOs;
using Negocio.TOs.Configuration;

namespace SeniorConnect.Controllers
{
    [ApiController]
    [Route("Token/v1")]
    public class TokenController : BaseController
    {
        public JwtConfigurationOptions JwtConfigurationOptions { get; set; }

        public TokenController(ApplicationContext applicationContext, JwtConfigurationOptions jwtConfigurationOptions) : base(applicationContext)
        {
            JwtConfigurationOptions = jwtConfigurationOptions;
        }

        [HttpGet("CreateToken")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken(string username, string password)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository(ApplicationContext);

                var usuarioModel = await usuarioRepository.GetByUserAndPassword(username, password);

                if (usuarioModel == null)
                    return NotFound(ApiResponseTO<object>.CreateFalha("O usuário informado não existe ou a senha não está correta."));

                var tokenService = new TokenHelper(JwtConfigurationOptions);

                return Ok(ApiResponseTO<TokenTO>.CreateSucesso(new TokenTO()
                {
                    Token = tokenService.CreateAccessToken(usuarioModel),
                    Type = "bearer",
                    Expiration = JwtConfigurationOptions.ExpirationSeconds
                }));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                return null;
            }
        }
    }
}
