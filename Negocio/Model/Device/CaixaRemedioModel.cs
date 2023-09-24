using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.Device
{
    public class CaixaRemedioModel : IoTDeviceModel
    {
        public string Descricao { get; set; }
        public int QuantidadeContainers { get; set; }
    }
}
