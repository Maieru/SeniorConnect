using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Negocio.Context;
using Negocio.Database;
using Negocio.Model.Device;
using Negocio.Model.IotMessage;
using Negocio.Repository.DeviceRepository;
using Negocio.Repository.LembreteMedicamentoRepository;
using Negocio.Repository.LembreteRepository;
using Negocio.TOs;
using Negocio.TOs.IotMessage;

namespace IoTGateway.Controllers
{
    [ApiController]
    [Route("IoTMessage/v1")]
    public class IoTMessageV1Controller : Controller
    {
        public ApplicationContext ApplicationContext { get; set; }
        public IotDriver IotDriver { get; set; }

        public IoTMessageV1Controller(IotDriver iotDriver, ApplicationContext applicationContext)
        {
            IotDriver = iotDriver;
            ApplicationContext = applicationContext;
        }

        [HttpPost("AtualizaDadosPulseira")]
        [Produces(typeof(ApiResponseTO<StatusPulseiraModel>))]
        [ProducesResponseType(typeof(ApiResponseTO<StatusPulseiraModel>), 200)]
        [ProducesResponseType(typeof(ApiResponseTO<object>), 404)]
        public async Task<IActionResult> AtualizaDadosPulseira([FromBody] StatusPulseiraTO pulseiraMessage)
        {
            if (!await ValidaDispositivo(pulseiraMessage))
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            var pulseiraDatabase = IotDriver.GetIoTMessagePulseiraCollection();

            var statusPulseiraModel = new StatusPulseiraModel(pulseiraMessage);
            await pulseiraDatabase.InsertOneAsync(statusPulseiraModel);

            return Ok(ApiResponseTO<StatusPulseiraModel>.CreateSucesso(statusPulseiraModel));
        }

        [HttpPost("AtualizaDadosCaixaRemedio")]
        [Produces(typeof(ApiResponseTO<StatusCaixaRemedioModel>))]
        [ProducesResponseType(typeof(ApiResponseTO<StatusCaixaRemedioModel>), 200)]
        [ProducesResponseType(typeof(ApiResponseTO<object>), 404)]
        public async Task<IActionResult> AtualizaDadosCaixaRemedio([FromBody] StatusCaixaRemedioTO caixaRemedioMessage)
        {
            if (!await ValidaDispositivo(caixaRemedioMessage))
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            var caixaRemedioDatabase = IotDriver.GetIoTMessageCaixaCollection();

            var caixaRemedioModel = new StatusCaixaRemedioModel(caixaRemedioMessage);
            await caixaRemedioDatabase.InsertOneAsync(caixaRemedioModel);

            return Ok(ApiResponseTO<StatusCaixaRemedioModel>.CreateSucesso(caixaRemedioModel));
        }

        [HttpGet("GetDadosCaixaRemedio")]
        [Produces(typeof(ApiResponseTO<EnviarCaixaRemedioTO>))]
        [ProducesResponseType(typeof(ApiResponseTO<EnviarCaixaRemedioTO>), 200)]
        [ProducesResponseType(typeof(ApiResponseTO<object>), 404)]
        public async Task<IActionResult> GetDadosCaixaRemedio([FromBody] IotMessageTO deviceInfo)
        {
            if (!await ValidaDispositivo(deviceInfo))
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            var device = await GetDevice(deviceInfo);

            var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
            var agendamentosDoDispositivo = await lembreteMedicamentoRepository.GetLembretesMedicamentoByDevice(device);

            var mensagemCaixaRemedio = new EnviarCaixaRemedioTO(device.DeviceId, device.DeviceKey);
            mensagemCaixaRemedio.Agendamentos = agendamentosDoDispositivo.Select(x => x?.Horario).ToList();

            return Ok(ApiResponseTO<EnviarCaixaRemedioTO>.CreateSucesso(mensagemCaixaRemedio));
        }

        [HttpGet("GetDadosPulseira")]
        [Produces(typeof(ApiResponseTO<EnviarPulseiraTO>))]
        [ProducesResponseType(typeof(ApiResponseTO<EnviarPulseiraTO>), 200)]    
        [ProducesResponseType(typeof(ApiResponseTO<object>), 404)]
        public async Task<IActionResult> GetDadosPulseira([FromBody] IotMessageTO deviceInfo)
        {
            if (!await ValidaDispositivo(deviceInfo))
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            var device = await GetDevice(deviceInfo);

            var lembreteRepository = new LembreteRepository(ApplicationContext);
            var lembretesDoDispositivo = await lembreteRepository.GetLembretesByDevice(device);

            var mensagemPulsiera = new EnviarPulseiraTO(device.DeviceId, device.DeviceKey);
            mensagemPulsiera.Alertas = lembretesDoDispositivo.Select(l => new AlertaTO(l.Horario, l.Descricao)).ToList();

            return Ok(ApiResponseTO<EnviarPulseiraTO>.CreateSucesso(mensagemPulsiera));
        }

        private async Task<IoTDeviceModel> GetDevice(IotMessageTO iotMessage)
        {
            var deviceRepository = new DeviceRepository(ApplicationContext);
            return await deviceRepository.GetByIdentification(iotMessage.DeviceId.Value, iotMessage.DeviceKey);
        }

        private async Task<bool> ValidaDispositivo(IotMessageTO iotMessage)
        {
            // TODO: Colocar validação do device
            return true;
        }
    }
}
