using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Negocio.Context;
using Negocio.Database;
using Negocio.Enum;
using Negocio.Model;
using Negocio.Model.IotMessage;
using Negocio.Repository.Device;
using Negocio.TOs;

namespace SeniorConnect.Controllers
{

    [Route("Dashboard/v1")]
    [ApiController]
    public class DashboardController : BaseController
    {
        private IotDriver _driver;
        public DashboardController(ApplicationContext applicationContext, IotDriver driver) : base(applicationContext)
        {
            _driver = driver;
        }

        [HttpGet("ContagemBtEmergencia")]
        public async Task<IActionResult> ContagemBtEmergencia(int assinatura)
        {
            try
            {
                var dispositivoRepository = new DeviceRepository(ApplicationContext);
                var dispositivo = await dispositivoRepository.GetByAssinaturaId(assinatura);

                var pulseira = dispositivo.Where(l => l.DeviceType == EnumDeviceType.Pulseira).FirstOrDefault();

                var pulseiraMessageCollection = _driver.GetIoTMessagePulseiraCollection();
                var filtroDispositivo = Builders<StatusPulseiraModel>.Filter.Eq(l => l.DeviceKey, pulseira.DeviceKey);
                var mensagensNaoProcessadas = await pulseiraMessageCollection.FindAsync<StatusPulseiraModel>(filtroDispositivo);

                int contador = 0;

                while (mensagensNaoProcessadas.MoveNext())
                {
                    foreach (var mensagem in mensagensNaoProcessadas.Current)
                    {
                        if (mensagem.BotaoEmergenciaPressionada)
                            contador++;
                    }
                }

                return Ok(ApiResponseTO<int>.CreateSucesso(contador));
            }

            catch
            {
                return null;
            }
        }
    }
}