using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Usuario;
using Negocio.TOs;

namespace SeniorConnect.Controllers
{
    [ApiController]
    [Route("Usuario/v1")]
    public class UsuarioController : BaseController
    {
        public UsuarioController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UsuarioTO usuario)
        {
            var transaction = ApplicationContext.Database.BeginTransaction();

            try
            {    
                var assinaturaRepository = new AssinaturaRepository(ApplicationContext);
                var usuarioRepository = new UsuarioRepository(ApplicationContext);
                var assinatura = new AssinaturaModel() { DataCriacao = DateTime.UtcNow, PlanoId = 1 };

                await assinaturaRepository.Insert(assinatura);

                var usuarioModel = new UsuarioModel()
                {
                    Usuario = usuario.Usuario,
                    SenhaPlain = usuario.Senha,
                    AssinaturaId = assinatura.Id
                };

                await usuarioRepository.Insert(usuarioModel);
                await transaction.CommitAsync();

                return Ok(ApiResponseTO<UsuarioModel>.CreateSucesso(usuarioModel));
            }
            catch (ArgumentException ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(ApiResponseTO<string>.CreateFalha(ex.Message));
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                await transaction.RollbackAsync();
                return null;
            }
        }
    }
}
