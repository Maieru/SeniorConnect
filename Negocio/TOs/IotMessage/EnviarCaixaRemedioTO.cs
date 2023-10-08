using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs.IotMessage
{
    public class EnviarCaixaRemedioTO : IotMessageTO
    {
        public EnviarCaixaRemedioTO() { }
        public EnviarCaixaRemedioTO(int? deviceId, string? deviceKey) : base(deviceId, deviceKey) { }

        public List<DateTime?> Agendamentos { get; set; }
    }
}
