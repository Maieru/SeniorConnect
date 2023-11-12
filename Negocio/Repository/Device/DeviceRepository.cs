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

        public async Task<int> Delete(int id)
        {
            var transaction = _applicationContext.Database.BeginTransaction();

            try
            {
                var deviceModel = await GetById(id);

                if (deviceModel == null)
                    return 0;

                _applicationContext.IoTDevices.Remove(deviceModel);
                var registrosAlterados = await _applicationContext.SaveChangesAsync();
                transaction.Commit();

                return registrosAlterados;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
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
        public async Task<IoTDeviceModel?> GetById(int id) => await _applicationContext.IoTDevices.FirstOrDefaultAsync(a => a.DeviceId == id);

        public async Task<int> Update(IoTDeviceModel device)
        {
            if (!await _applicationContext.IoTDevices.AnyAsync(d => d.DeviceId == device.DeviceId && d.DeviceKey == device.DeviceKey))
                return 0;

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
