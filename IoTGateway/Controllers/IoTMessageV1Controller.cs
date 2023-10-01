using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Negocio.Context;
using Negocio.Model.IotMessage;
using Negocio.TOs;
using Negocio.TOs.IotMessage;

namespace IoTGateway.Controllers
{
    [ApiController]
    [Route("IoTMessage/v1")]
    public class IoTMessageV1Controller : Controller
    {
        public IotDriver IotDriver { get; set; }

        public IoTMessageV1Controller(IotDriver iotDriver) => IotDriver = iotDriver;

        [HttpPost("AtualizaDadosPulseira")]
        [Produces(typeof(ApiResponseTO))]
        [ProducesResponseType(typeof(ApiResponseTO), 200)]
        [ProducesResponseType(typeof(ApiResponseTO), 404)]
        public async Task<IActionResult> AtualizaDadosPulseira([FromBody] StatusPulseiraTO pulseiraMessage)
        {
            if (!await ValidaDispositivoValido(pulseiraMessage))
                return NotFound(ApiResponseTO.CreateFalha("Não foi possivel localizada o dispositivo"));

            var pulseiraDatabase = IotDriver.GetIoTMessagePulseiraCollection();

            var statusPulseiraModel = new StatusPulseiraModel(pulseiraMessage);
            await pulseiraDatabase.InsertOneAsync(statusPulseiraModel);

            return Ok(ApiResponseTO.CreateSucesso(statusPulseiraModel));
        }

        [HttpPost("AtualizaDadosCaixaRemedio")]
        [Produces(typeof(ApiResponseTO))]
        [ProducesResponseType(typeof(ApiResponseTO), 200)]
        [ProducesResponseType(typeof(ApiResponseTO), 404)]
        public async Task<IActionResult> AtualizaDadosCaixaRemedio([FromBody] StatusCaixaRemedioTO caixaRemedioMessage)
        {
            if (!await ValidaDispositivoValido(caixaRemedioMessage))
                return NotFound(ApiResponseTO.CreateFalha("Não foi possivel localizada o dispositivo"));

            var caixaRemedioDatabase = IotDriver.GetIoTMessageCaixaCollection();

            var caixaRemedioModel = new StatusCaixaRemedioModel(caixaRemedioMessage);
            await caixaRemedioDatabase.InsertOneAsync(caixaRemedioModel);

            return Ok(ApiResponseTO.CreateSucesso(caixaRemedioModel));
        }

        private async Task<bool> ValidaDispositivoValido(IotMessageTO iotMessage)
        {
            // TODO: Colocar validação do device
            return true;
        }
    }
}
