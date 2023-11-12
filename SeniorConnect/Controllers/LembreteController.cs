using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Lembrete;
using Negocio.TOs;

namespace SeniorConnect.Controllers
{
    [Route("Lembrete/v1")]
    [ApiController]
    public class LembreteController : BaseController
    {
        public LembreteController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] LembreteModel lembrete)
        {
            try
            {
                var lembretesRepository = new LembreteRepository(ApplicationContext);
                var resultado = await lembretesRepository.Insert(lembrete);
                
                return Ok(ApiResponseTO<LembreteModel>.CreateSucesso(lembrete));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponseTO<string>.CreateFalha(ex.Message));
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                return null;
            }
        }

        [HttpPost("Editar")]
        public async Task<IActionResult> Editar([FromBody] LembreteModel lembrete)
        {
            try
            {
                var lembretesRepository = new LembreteRepository(ApplicationContext);
                var resultado = await lembretesRepository.Update(lembrete);

                return Ok(ApiResponseTO<LembreteModel>.CreateSucesso(lembrete));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponseTO<string>.CreateFalha(ex.Message));
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                return null;
            }
        }

        [HttpGet("RecuperaLembrete/{lembreteId}")]
        public async Task<IActionResult> RecuperaLembrete(int lembreteId)
        {
            try
            {
                var lembretesRepository = new LembreteRepository(ApplicationContext);
                var lembrete = await lembretesRepository.GetById(lembreteId);

                return Ok(ApiResponseTO<LembreteModel>.CreateSucesso(lembrete));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponseTO<string>.CreateFalha(ex.Message));
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                return null;
            }
        }

        [HttpDelete("Deletar/{lembreteId}")]
        public async Task<IActionResult> Deletar(int lembreteId)
        {
            try
            {
                var lembreteRepository = new LembreteRepository(ApplicationContext);
                await lembreteRepository.Delete(lembreteId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponseTO<string>.CreateFalha(ex.Message));
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                return null;
            }
        }

        [HttpGet("RecuperaLembretesDaAssinatura/{assinatura}")]
        public async Task<IActionResult> RecuperaLembretesDaAssinatura(int assinatura)
        {
            try
            {
                var assinaturaRepository = new AssinaturaRepository(ApplicationContext);
                var assinaturaModel = await assinaturaRepository.GetById(assinatura);

                if (assinaturaModel == null)
                    return NotFound(ApiResponseTO<object>.CreateFalha("A assinatura informada não existe."));

                var lembretesRepository = new LembreteRepository(ApplicationContext);
                var lembretes = await lembretesRepository.GetByAssinaturaId(assinatura);

                return Ok(ApiResponseTO<List<LembreteModel>>.CreateSucesso(lembretes));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponseTO<string>.CreateFalha(ex.Message));
            }
            catch (Exception ex)
            {
                await LoggerHelper.GeraLogErro(ex);
                return null;
            }
        }
    }
}
