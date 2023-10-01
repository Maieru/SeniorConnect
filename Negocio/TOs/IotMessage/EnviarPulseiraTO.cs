using Negocio.Model;

namespace Negocio.TOs.IotMessage
{
    public class EnviarPulseiraTO : IotMessageTO
    {
        public List<LembreteModel> Alertas { get; set; } 
    }
}
