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

        public async Task<MedicamentoModel?> GetById(int id) => await _applicationContext.Medicamentos.FirstOrDefaultAsync(a => a.Id == id);

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
            if (!await VerificaSeAssinaturaExiste(medicamento.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrada");

            await _applicationContext.Medicamentos.AddAsync(medicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Update(MedicamentoModel medicamento)
        {
            if (!await _applicationContext.Medicamentos.AnyAsync(m => m.Id == medicamento.Id))
                return 0;

            if (!await VerificaSeAssinaturaExiste(medicamento.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrada");

            _applicationContext.Medicamentos.Update(medicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaId)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaId) != null;
        }
    }
}