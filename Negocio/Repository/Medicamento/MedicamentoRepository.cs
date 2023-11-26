using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Medicamento
{
    public class MedicamentoRepository : BaseEntityRepository, IMedicamentoRepository
    {
        public MedicamentoRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<List<MedicamentoModel>> GetByAssinaturaId(int assinaturaId) => await _applicationContext.Medicamentos.Where(l => l.AssinaturaId == assinaturaId).ToListAsync();

        public async Task<List<MedicamentoModel>> GetByDevice(IoTDeviceModel device)
        {
            var medicamentos = await _applicationContext.MedicamentoIoTDevice.Where(l => l.IoTDeviceId == device.DeviceId).Select(l => l.MedicamentoId).ToListAsync();
            return await _applicationContext.Medicamentos.Where(l => medicamentos.Contains(l.Id)).ToListAsync();
        }

        public async Task<IEnumerable<MedicamentoModel>> GetAll() => await _applicationContext.Medicamentos.ToListAsync();

        public async Task<MedicamentoModel?> GetById(int id)
        {
            var medicamento = await _applicationContext.Medicamentos.FirstOrDefaultAsync(a => a.Id == id);

            if (medicamento != null)
                medicamento.DispositivosAssociados = await GetDevicesAssociated(id);

            return medicamento;
        }

        public async Task<int> Delete(int id)
        {
            var medicamento = await GetById(id);

            if (medicamento == null)
                return 0;

            _applicationContext.Medicamentos.Remove(medicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(MedicamentoModel medicamento)
        {
            var transaction = _applicationContext.Database.BeginTransaction();

            try
            {
                if (!await VerificaSeAssinaturaExiste(medicamento.AssinaturaId))
                    throw new ArgumentException("Assinatura não encontrada");

                await _applicationContext.Medicamentos.AddAsync(medicamento);
                var result = await _applicationContext.SaveChangesAsync();

                if (medicamento.DispositivosAssociados != null)
                {
                    foreach (var device in medicamento.DispositivosAssociados)
                    {
                        if (!await _applicationContext.IoTDevices.AnyAsync(d => d.DeviceId == device))
                            throw new ArgumentException($"Dispositivo {device} não existe");

                        await _applicationContext.MedicamentoIoTDevice.AddAsync(new MedicamentoIoTDeviceModel { IoTDeviceId = device, MedicamentoId = medicamento.Id });
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

        public async Task<int> Update(MedicamentoModel medicamento)
        {
            var transaction = _applicationContext.Database.BeginTransaction();

            try
            {
                if (!await _applicationContext.Medicamentos.AnyAsync(m => m.Id == medicamento.Id))
                    return 0;

                if (!await VerificaSeAssinaturaExiste(medicamento.AssinaturaId))
                    throw new ArgumentException("Assinatura não encontrada");

                if (medicamento.DispositivosAssociados != null)
                {
                    var associacoes = await _applicationContext.MedicamentoIoTDevice.Where(l => l.MedicamentoId == medicamento.Id).ToListAsync();
                    _applicationContext.MedicamentoIoTDevice.RemoveRange(associacoes);

                    foreach (var device in medicamento.DispositivosAssociados)
                    {
                        if (!await _applicationContext.IoTDevices.AnyAsync(d => d.DeviceId == device))
                            throw new ArgumentException($"Dispositivo {device} não existe");

                        await _applicationContext.MedicamentoIoTDevice.AddAsync(new MedicamentoIoTDeviceModel { IoTDeviceId = device, MedicamentoId = medicamento.Id });
                    }
                }

                _applicationContext.Medicamentos.Update(medicamento);
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

        public async Task<List<int>> GetDevicesAssociated(int medicamentoId) => await _applicationContext.MedicamentoIoTDevice.Where(l => l.MedicamentoId == medicamentoId).Select(l => l.IoTDeviceId).ToListAsync();

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaId)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaId) != null;
        }
    }
}