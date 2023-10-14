using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.AssinaturaRepository
{
    public interface IAssinaturaRepository
    {
        Task<IEnumerable<AssinaturaModel>> GetAll();
        Task<AssinaturaModel> GetById(int id);
        Task<int> Insert(AssinaturaModel assinatura);
        Task<int> Update(AssinaturaModel assinatura);
        Task<int> Delete(int id);
    }
}
