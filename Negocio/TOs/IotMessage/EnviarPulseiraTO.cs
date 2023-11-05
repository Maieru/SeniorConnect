using Negocio.Model;

namespace Negocio.TOs.IotMessage
{
    public class EnviarPulseiraTO : IotMessageTO
    {
        public List<AlertaTO> Alertas { get; set; }

        public EnviarPulseiraTO() { }
        public EnviarPulseiraTO(int? deviceId, string? deviceKey) : base(deviceId, deviceKey) { }
    }
}
