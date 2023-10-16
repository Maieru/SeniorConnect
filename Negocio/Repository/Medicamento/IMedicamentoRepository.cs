using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Medicamento
{
    public interface IMedicamentoRepository
    {
        Task<IEnumerable<MedicamentoModel>> GetAll();
        Task<MedicamentoModel> GetById(int id);
        Task<int> Insert(MedicamentoModel medicamento);
        Task<int> Update(MedicamentoModel medicamento);
        Task<int> Delete(int id);
    }
}