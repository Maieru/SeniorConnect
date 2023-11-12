using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Medicamento;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Lembrete
{
    public class LembreteRepository : BaseEntityRepository, ILembreteRepository
    {
        public LembreteRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<List<LembreteModel>> GetByAssinaturaId(int assinaturaId) => await _applicationContext.Lembretes.Where(l => l.AssinaturaId == assinaturaId).ToListAsync();

        public async Task<List<LembreteModel>> GetByDevice(IoTDeviceModel device)
        {
            var lembretesAssociados = await _applicationContext.LembreteIoTDevice.Where(l => l.IoTDeviceId == device.DeviceId).Select(l => l.LembreteId).ToListAsync();
            return await _applicationContext.Lembretes.Where(l => lembretesAssociados.Contains(l.Id)).ToListAsync();
        }

        public async Task<List<int>> GetDevicesAssociated(int lembreteId) => await _applicationContext.LembreteIoTDevice.Where(l => l.LembreteId == lembreteId).Select(l => l.IoTDeviceId).ToListAsync();

        public async Task<IEnumerable<LembreteModel>> GetAll() => await _applicationContext.Lembretes.ToListAsync();

        public async Task<LembreteModel?> GetById(int id)
        {
            var lembrete = await _applicationContext.Lembretes.FirstOrDefaultAsync(a => a.Id == id);

            if (lembrete != null)
                lembrete.DispositivosAssociados = await GetDevicesAssociated(id);

            return lembrete;
        }

        public async Task<int> Delete(int id)
        {
            var lembrete = await GetById(id);

            if (lembrete == null)
                return 0;

            _applicationContext.Lembretes.Remove(lembrete);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(LembreteModel lembrete)
        {
            var transaction = _applicationContext.Database.BeginTransaction();

            try
            {
                if (!await VerificaSeAssinaturaExiste(lembrete.AssinaturaId))
                    throw new ArgumentException("Assinatura não encontrada");

                await _applicationContext.Lembretes.AddAsync(lembrete);
                var result = await _applicationContext.SaveChangesAsync();

                if (lembrete.DispositivosAssociados != null)
                {
                    foreach (var device in lembrete.DispositivosAssociados)
                    {
                        if (!await _applicationContext.IoTDevices.AnyAsync(d => d.DeviceId == device))
                            throw new ArgumentException($"Dispositivo {device} não existe");

                        await _applicationContext.LembreteIoTDevice.AddAsync(new LembreteIoTDeviceModel { IoTDeviceId = device, LembreteId = lembrete.Id });
                    }
                }

                result += await _applicationContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> Update(LembreteModel lembrete)
        {
            var transaction = _applicationContext.Database.BeginTransaction();

            try
            {
                if (!await _applicationContext.Lembretes.AnyAsync(l => l.Id == lembrete.Id))
                    return 0;

                if (!await VerificaSeAssinaturaExiste(lembrete.AssinaturaId))
                    throw new ArgumentException("Novo plano não encontrado");

                if (lembrete.DispositivosAssociados != null)
                {
                    var associacoes = await _applicationContext.LembreteIoTDevice.Where(l => l.LembreteId == lembrete.Id).ToListAsync();
                    _applicationContext.LembreteIoTDevice.RemoveRange(associacoes);

                    foreach (var device in lembrete.DispositivosAssociados)
                    {
                        if (!await _applicationContext.IoTDevices.AnyAsync(d => d.DeviceId == device))
                            throw new ArgumentException($"Dispositivo {device} não existe");

                        await _applicationContext.LembreteIoTDevice.AddAsync(new LembreteIoTDeviceModel { IoTDeviceId = device, LembreteId = lembrete.Id });
                    }
                }

                _applicationContext.Lembretes.Update(lembrete);
                var result = await _applicationContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaid)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaid) != null;
        }
    }
}
