using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.Device
{
    public class CaixaRemedioModel : IoTDeviceModel
    {
        [Column("QuantidadeContainer")]
        public int QuantidadeContainers { get; set; }

        public CaixaRemedioModel() { }

        public CaixaRemedioModel(int deviceId, string deviceKey) : base(deviceId, deviceKey) { }
    }
}
