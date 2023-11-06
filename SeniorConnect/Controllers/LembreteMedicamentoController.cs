using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.LembreteMedicamento;
using Negocio.Repository.Medicamento;
using Negocio.TOs;

namespace SeniorConnect.Controllers
{
    [Route("LembreteMedicamento/v1")]
    [ApiController]
    public class LembreteMedicamentoController : BaseController
    {
        public LembreteMedicamentoController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] LembreteMedicamentoModel lembreteMedicamento)
        {
            try
            {
                var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
                var resultado = await lembreteMedicamentoRepository.Insert(lembreteMedicamento);

                return Ok(ApiResponseTO<LembreteMedicamentoModel>.CreateSucesso(lembreteMedicamento));
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
        public async Task<IActionResult> Editar([FromBody] LembreteMedicamentoModel lembreteMedicamento)
        {
            try
            {
                var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
                var resultado = await lembreteMedicamentoRepository.Update(lembreteMedicamento);

                return Ok(ApiResponseTO<LembreteMedicamentoModel>.CreateSucesso(lembreteMedicamento));
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

        [HttpGet("RecuperaLembreteMedicamento/{lembreteMedicamentoId}")]
        public async Task<IActionResult> RecuperaLembreteMedicamento(int lembreteMedicamentoId)
        {
            try
            {
                var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
                var lembreteMedicamento = await lembreteMedicamentoRepository.GetById(lembreteMedicamentoId);

                return Ok(ApiResponseTO<LembreteMedicamentoModel>.CreateSucesso(lembreteMedicamento));
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

        [HttpDelete("Deletar/{lembreteMedicamentoId}")]
        public async Task<IActionResult> Deletar(int lembreteMedicamentoId)
        {
            try
            {
                var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
                await lembreteMedicamentoRepository.Delete(lembreteMedicamentoId);
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

        [HttpGet("RecuperaMedicamento/{medicamento}")]
        public async Task<IActionResult> RecuperaMedicamento(int medicamento)
        {
            try
            {
                var medicamentoRepository = new MedicamentoRepository(ApplicationContext);
                var medicamentoModel = await medicamentoRepository.GetById(medicamento);

                if (medicamentoModel == null)
                    return NotFound(ApiResponseTO<object>.CreateFalha("O médico informado não existe."));

                var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
                var lembreteMedicamento = await lembreteMedicamentoRepository.GetByMedicamentoId(medicamento);

                return Ok(ApiResponseTO<List<LembreteMedicamentoModel>>.CreateSucesso(lembreteMedicamento));
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
