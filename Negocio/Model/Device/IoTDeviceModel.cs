using Negocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.Device
{
    public abstract class IoTDeviceModel
    {
        public int DeviceId { get; set; }
        public string? DeviceKey { get; set; }
        public EnumDeviceType DeviceType { get; set; }
        public int AssinaturaId { get; set; }

        public IoTDeviceModel() { }

        public IoTDeviceModel(int deviceId, string deviceKey)
        {
            DeviceId = deviceId;
            DeviceKey = deviceKey;
        }
    }
}
