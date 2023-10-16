using Negocio.Model;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Medicamento
{
    public class MedicamentoRepository : BaseEntityRepository, IAssinaturaRepository
    {
        public MedicamentoRepository(ApplicationContext applicationContext) : base(applicationContext)
        { 
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

        public async Task<int> Insert(MedicamentoModel medicamentos)
        {
            if (!await VerificaSePlanoExiste(medicamentos.MedicamentoId))
                throw new ArgumentException("Novo medicamento não encontrado");

            await _applicationContext.Assinaturas.AddAsync(medicamentos);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(MedicamentoModel medicamento)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> VerificaSePlanoExiste(int planoId)
        {

        }
    }

}