using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Lembrete
{
    public interface ILembreteRepository
    {
        Task<List<LembreteModel>> GetByAssinaturaId(int assinaturaId);
        Task<IEnumerable<LembreteModel>> GetAll();
        Task<LembreteModel> GetById(int id);
        Task<int> Insert(LembreteModel lembrete);
        Task<int> Update(LembreteModel lembrete);
        Task<int> Delete(int id);
        Task<List<int>> GetDevicesAssociated(int lembreteId);
    }
}
