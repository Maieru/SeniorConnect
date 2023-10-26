using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> GetByUserAndPassword(string usuario, string password);
        Task<IEnumerable<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetById(int id);
        Task<int> Insert(UsuarioModel usuario);
        Task<int> Update(UsuarioModel usuario);
        Task<int> Delete(int id);

    }
}
