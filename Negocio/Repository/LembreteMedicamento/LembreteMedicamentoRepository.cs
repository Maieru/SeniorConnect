using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
using Negocio.Repository.Medicamento;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.LembreteMedicamento
{
    public class LembreteMedicamentoRepository : BaseEntityRepository, ILembreteMedicamentoRepository
    {
        public LembreteMedicamentoRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<List<List<LembreteMedicamentoModel>>> GetByDevice(CaixaRemedioModel device)
        {
            var medicamentoRepository = new MedicamentoRepository(_applicationContext);
            var medicamentosDoDevice = await medicamentoRepository.GetByDevice(device);

            var retorno = new List<List<LembreteMedicamentoModel>>();

            for (var i = 1; i <= device.QuantidadeContainers; i++)
            {
                var medicamentoNoContainer = medicamentosDoDevice.FirstOrDefault(m => m.PosicaoNaCaixaRemedio == i);

                if (medicamentoNoContainer == null)
                    retorno.Add(null);
                else
                    retorno.Add(await GetByMedicamentoId(medicamentoNoContainer.Id));
            }

            return retorno;
        }

        public async Task<IEnumerable<LembreteMedicamentoModel>> GetAll() => await _applicationContext.LembreteMedicamentos.ToListAsync();

        public async Task<LembreteMedicamentoModel?> GetById(int id) => await _applicationContext.LembreteMedicamentos.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<List<LembreteMedicamentoModel>> GetByMedicamentoId(int id) => await _applicationContext.LembreteMedicamentos.Where(a => a.MedicamentoId == id).ToListAsync();

        public async Task<int> Delete(int id)
        {
            var lembreteMedicamento = await GetById(id);

            if (lembreteMedicamento == null)
                return 0;

            _applicationContext.LembreteMedicamentos.Remove(lembreteMedicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(LembreteMedicamentoModel lembreteMedicamento)
        {
            if (!await VerificaSeMedicamentoExiste(lembreteMedicamento.MedicamentoId))
                throw new ArgumentException("Novo plano não encontrado");

            await _applicationContext.LembreteMedicamentos.AddAsync(lembreteMedicamento);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(LembreteMedicamentoModel lembreteMedicamento)
        {
            if (await GetById(lembreteMedicamento.Id) == null)
                return 0;

            if (!await VerificaSeMedicamentoExiste(lembreteMedicamento.MedicamentoId))
                throw new ArgumentException("Novo plano não encontrado");

            _applicationContext.LembreteMedicamentos.Update(lembreteMedicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeMedicamentoExiste(int medicamentoId)
        {
            var MedicamentoRepository = new MedicamentoRepository(_applicationContext);
            return await MedicamentoRepository.GetById(medicamentoId) != null;
        }
    }
}