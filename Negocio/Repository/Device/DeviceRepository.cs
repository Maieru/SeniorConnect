using Microsoft.EntityFrameworkCore;
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

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IoTDeviceModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<IoTDeviceModel>> GetByAssinaturaId(int assinaturaId) => await _applicationContext.IoTDevices.Where(d => d.AssinaturaId == assinaturaId).ToListAsync();

        public async Task<IoTDeviceModel> GetByIdentification(int deviceId, string deviceKey) => await _applicationContext.IoTDevices.FirstOrDefaultAsync(d => d.DeviceId == deviceId && d.DeviceKey == deviceKey);         

        public Task<int> Insert(IoTDeviceModel assinatura)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(IoTDeviceModel assinatura)
        {
            throw new NotImplementedException();
        }
    }
}
