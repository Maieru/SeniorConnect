using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Medicamento;
using Negocio.TOs;

namespace SeniorConnect.Controllers
{
    [Route("Medicamento/v1")]
    [ApiController]
    public class MedicamentoController : BaseController
    {
        public MedicamentoController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] MedicamentoModel medicamento)
        {
            try
            {
                var medicamentoRepository = new MedicamentoRepository(ApplicationContext);
                var resultado = await medicamentoRepository.Insert(medicamento);

                return Ok(ApiResponseTO<MedicamentoModel>.CreateSucesso(medicamento));
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
        public async Task<IActionResult> Editar([FromBody] MedicamentoModel medicamento)
        {
            try
            {
                var medicamentoRepository = new MedicamentoRepository(ApplicationContext);
                var resultado = await medicamentoRepository.Update(medicamento);

                return Ok(ApiResponseTO<MedicamentoModel>.CreateSucesso(medicamento));
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

        [HttpGet("RecuperaMedicamento/{medicamentoId}")]
        public async Task<IActionResult> RecuperaMedicamento(int medicamentoId)
        {
            try
            {
                var medicamentoRepository = new MedicamentoRepository(ApplicationContext);
                var medicamento = await medicamentoRepository.GetById(medicamentoId);

                return Ok(ApiResponseTO<MedicamentoModel>.CreateSucesso(medicamento));
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

        [HttpDelete("Deletar/{medicamentoId}")]
        public async Task<IActionResult> Deletar(int medicamentoId)
        {
            try
            {
                var medicamentoRepository = new MedicamentoRepository(ApplicationContext);
                await medicamentoRepository.Delete(medicamentoId);
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

                var medicamentoRepository = new MedicamentoRepository(ApplicationContext);
                var medicamento = await medicamentoRepository.GetByAssinaturaId(assinatura);

                return Ok(ApiResponseTO<List<MedicamentoModel>>.CreateSucesso(medicamento));
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
