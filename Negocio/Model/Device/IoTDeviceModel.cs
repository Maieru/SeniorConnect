using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.Device
{
    public abstract class IoTDeviceModel
    {
        public int Id { get; set; }
        public string DeviceKey { get; set; }
        public int AssinaturaId { get; set; }
    }
}
