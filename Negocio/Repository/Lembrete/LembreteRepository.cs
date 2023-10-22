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

        public async Task<IEnumerable<LembreteModel>> GetAll() => await _applicationContext.Lembretes.ToListAsync();

        public async Task<LembreteModel?> GetById(int id) => await _applicationContext.Lembretes.FirstOrDefaultAsync(a => a.Id == id);

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
            if (!await VerificaSeAssinaturaExiste(lembrete.AssinaturaId))
                throw new ArgumentException("Novo plano não encontrado");

            await _applicationContext.Lembretes.AddAsync(lembrete);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(LembreteModel lembrete)
        {
            if (await GetById(lembrete.Id) == null)
                return 0;

            if (!await VerificaSeAssinaturaExiste(lembrete.AssinaturaId))
                throw new ArgumentException("Novo plano não encontrado");

            _applicationContext.Lembretes.Update(lembrete);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaid)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaid) != null;
        }
    }
}
