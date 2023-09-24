using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.IotMessage
{
    public class StatusPulseiraModel : IotMessageModel
    {
        public int BatimentoCardiaco { get; set; }
        public bool QuedaDetectada { get; set; }
        public bool BotaoEmergenciaPressionada { get; set; }
    }
}