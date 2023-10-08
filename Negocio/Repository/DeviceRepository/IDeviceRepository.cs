using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.DeviceRepository
{
    public interface IDeviceRepository
    {
        public Task<IoTDeviceModel> GetByIdentification(int deviceId, string deviceKey); 
    }
}
