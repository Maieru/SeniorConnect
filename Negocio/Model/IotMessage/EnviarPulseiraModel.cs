using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.IotMessage
{
    public class EnviarPulseiraModel : IotMessageModel
    {
        public List<LembreteModel> Alertas { get; set; } 
    }
}
