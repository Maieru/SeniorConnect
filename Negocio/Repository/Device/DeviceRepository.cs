using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model.Device;
using Negocio.Repository.Assinatura;
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

        public async Task<List<IoTDeviceModel>> GetByAssinaturaId(int assinaturaId) => await _applicationContext.IoTDevices.Where(d => d.AssinaturaId == assinaturaId).ToListAsync();

        public async Task<IoTDeviceModel> GetByIdentification(int deviceId, string deviceKey) => await _applicationContext.IoTDevices.FirstOrDefaultAsync(d => d.DeviceId == deviceId && d.DeviceKey == deviceKey);         

        public async Task<int> Insert(IoTDeviceModel device)
        {
            if (!await VerificaSeAssinaturaExiste(device.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrado");

            await _applicationContext.IoTDevices.AddAsync(device);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Update(IoTDeviceModel device)
        {
            if (!await VerificaSeAssinaturaExiste(device.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrado");

            _applicationContext.IoTDevices.Update(device);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaId)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaId) != null;
        }
    }
}
