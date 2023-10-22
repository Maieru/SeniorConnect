using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.LembreteMedicamento
{
    public interface ILembreteMedicamentoRepository
    {
        Task<List<List<LembreteMedicamentoModel>>> GetByDevice(CaixaRemedioModel device);
        Task<IEnumerable<LembreteMedicamentoModel>> GetAll();
        Task<LembreteMedicamentoModel> GetById(int id);
        Task<List<LembreteMedicamentoModel>> GetByMedicamentoId(int id);
        Task<int> Insert(LembreteMedicamentoModel lembreteMedicamento);
        Task<int> Update(LembreteMedicamentoModel lembreteMedicamento);
        Task<int> Delete(int id);
    }
}
