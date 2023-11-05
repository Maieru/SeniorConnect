using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.Device
{
    public class PulseiraModel : IoTDeviceModel
    {
        public PulseiraModel() { }

        public PulseiraModel(int deviceId, string deviceKey) : base(deviceId, deviceKey) { }
    }
}
