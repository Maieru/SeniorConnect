using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Model.Device;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Device;
using Negocio.Repository.Lembrete;
using Negocio.TOs;

namespace SeniorConnect.Controllers
{
    [Route("Device/v1")]
    [ApiController]
    public class DeviceController : BaseController
    {
        public DeviceController(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        [HttpPost("CriarPulseira")]
        public async Task<IActionResult> CriarPulseira([FromBody] PulseiraModel device)
        {
            try
            {
                return await CriarDevice(device);
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

        [HttpPost("CriarCaixaRemedio")]
        public async Task<IActionResult> CriarCaixaRemedio([FromBody] CaixaRemedioModel device)
        {
            try
            {
                return await CriarDevice(device);
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

        private async Task<IActionResult> CriarDevice(IoTDeviceModel device)
        {
            var deviceRepository = new DeviceRepository(ApplicationContext);
            await deviceRepository.Insert(device);

            return Ok(ApiResponseTO<IoTDeviceModel>.CreateSucesso(device));
        }

        [HttpPost("EditarPulseira")]
        public async Task<IActionResult> EditarPulseira([FromBody] PulseiraModel device)
        {
            try
            {
                return await Editar(device);
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

        [HttpPost("EditarCaixaRemedio")]
        public async Task<IActionResult> EditarCaixaRemedio([FromBody] CaixaRemedioModel device)
        {
            try
            {
                return await Editar(device);
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

        private async Task<IActionResult> Editar([FromBody] IoTDeviceModel device)
        {
            var deviceRepository = new DeviceRepository(ApplicationContext);
            var resultado = await deviceRepository.Update(device);

            return Ok(ApiResponseTO<IoTDeviceModel>.CreateSucesso(device));
        }

        [HttpGet("RecuperaDevice/{deviceId}")]
        public async Task<IActionResult> RecuperaDevice(int deviceId)
        {
            try
            {
                var deviceRepository = new DeviceRepository(ApplicationContext);
                var device = await deviceRepository.GetById(deviceId);

                return Ok(ApiResponseTO<IoTDeviceModel>.CreateSucesso(device));
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


        [HttpDelete("Deletar/{deviceId}")]
        public async Task<IActionResult> Deletar(int deviceId)
        {
            try
            {
                var deviceRepository = new DeviceRepository(ApplicationContext);
                await deviceRepository.Delete(deviceId);
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

        [HttpGet("RecuperaDevicesDaAssinatura/{assinatura}")]
        public async Task<IActionResult> RecuperaDevicesDaAssinatura(int assinatura)
        {
            try
            {
                var assinaturaRepository = new AssinaturaRepository(ApplicationContext);
                var assinaturaModel = await assinaturaRepository.GetById(assinatura);

                if (assinaturaModel == null)
                    return NotFound(ApiResponseTO<object>.CreateFalha("A assinatura informada não existe."));

                var DeviceRepository = new DeviceRepository(ApplicationContext);
                var devices = await DeviceRepository.GetByAssinaturaId(assinatura);

                return Ok(ApiResponseTO<List<IoTDeviceModel>>.CreateSucesso(devices));
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
