using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Negocio.Context;
using Negocio.Database;
using Negocio.Model.Device;
using Negocio.Model.IotMessage;
using Negocio.Repository.Device;
using Negocio.Repository.LembreteMedicamento;
using Negocio.Repository.Lembrete;
using Negocio.TOs;
using Negocio.TOs.IotMessage;
using Negocio.Enum;

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
            var dispositivo = await GetDevice(pulseiraMessage);
            
            if (dispositivo == null)
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            if (dispositivo.DeviceType != EnumDeviceType.Pulseira)
                return NotFound(ApiResponseTO<object>.CreateFalha("O dispositivo informado não era uma pulsiera"));

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
            var dispositivo = await GetDevice(caixaRemedioMessage);

            if (dispositivo == null)
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            if (dispositivo.DeviceType != EnumDeviceType.CaixaRemedio)
                return NotFound(ApiResponseTO<object>.CreateFalha("O dispositivo informado não era uma caixa de remédio"));

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
            var dispositivo = await GetDevice(deviceInfo);

            if (dispositivo == null)
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            if (dispositivo.DeviceType != EnumDeviceType.CaixaRemedio || dispositivo is not CaixaRemedioModel)
                return NotFound(ApiResponseTO<object>.CreateFalha("O dispositivo informado não era uma caixa de remédio"));

            var lembreteMedicamentoRepository = new LembreteMedicamentoRepository(ApplicationContext);
            var agendamentosDoDispositivo = await lembreteMedicamentoRepository.GetByDevice(dispositivo as CaixaRemedioModel);

            var mensagemCaixaRemedio = new EnviarCaixaRemedioTO(dispositivo.DeviceId, dispositivo.DeviceKey);

            mensagemCaixaRemedio.Agendamentos = new List<List<DateTime>>();
            foreach (var agendamentos in agendamentosDoDispositivo)
            {
                if (agendamentos == null)
                    mensagemCaixaRemedio.Agendamentos.Add(null);
                else
                    mensagemCaixaRemedio.Agendamentos.Add(agendamentos.Select(a => a.Horario).ToList());
            }

            return Ok(ApiResponseTO<EnviarCaixaRemedioTO>.CreateSucesso(mensagemCaixaRemedio));
        }

        [HttpGet("GetDadosPulseira")]
        [Produces(typeof(ApiResponseTO<EnviarPulseiraTO>))]
        [ProducesResponseType(typeof(ApiResponseTO<EnviarPulseiraTO>), 200)]    
        [ProducesResponseType(typeof(ApiResponseTO<object>), 404)]
        public async Task<IActionResult> GetDadosPulseira([FromBody] IotMessageTO deviceInfo)
        {
            var dispositivo = await GetDevice(deviceInfo);

            if (dispositivo == null)
                return NotFound(ApiResponseTO<object>.CreateFalha("Não foi possivel localizar o dispositivo"));

            if (dispositivo.DeviceType != EnumDeviceType.Pulseira)
                return NotFound(ApiResponseTO<object>.CreateFalha("O dispositivo informado não era uma pulseira"));

            var lembreteRepository = new LembreteRepository(ApplicationContext);
            var lembretesDoDispositivo = await lembreteRepository.GetByDevice(dispositivo);

            var mensagemPulsiera = new EnviarPulseiraTO(dispositivo.DeviceId, dispositivo.DeviceKey);
            mensagemPulsiera.Alertas = lembretesDoDispositivo.Select(l => new AlertaTO(l.Horario, l.Descricao)).ToList();

            return Ok(ApiResponseTO<EnviarPulseiraTO>.CreateSucesso(mensagemPulsiera));
        }

        private async Task<IoTDeviceModel> GetDevice(IotMessageTO iotMessage)
        {
            var deviceRepository = new DeviceRepository(ApplicationContext);
            return await deviceRepository.GetByIdentification(iotMessage.DeviceId.Value, iotMessage.DeviceKey);
        }                 
    }
}
