using Negocio.Database;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Device
{
    public class DeviceRepository : BaseEntityRepository, IDeviceRepository
    {
        public DeviceRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IoTDeviceModel> GetByIdentification(int deviceId, string deviceKey)
        {
            // TODO: Precisa Implementar
            return new CaixaRemedioModel(deviceId, deviceKey);
        }
    }
}
