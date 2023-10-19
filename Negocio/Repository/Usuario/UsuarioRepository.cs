using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Usuario
{
    public class UsuarioRepository : BaseEntityRepository, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<UsuarioModel>> GetAll() => await _applicationContext.Usuarios.ToListAsync();

        public async Task<UsuarioModel?> GetById(int id) => await _applicationContext.Usuarios.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> Insert(UsuarioModel usuario)
        {
            if (!await VerificaSeAssinaturaExiste(usuario.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrada");

            await _applicationContext.Usuarios.AddAsync(usuario);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Update(UsuarioModel usuario)
        {
            if (await GetById(usuario.Id) == null)
                return 0;

            if (!await VerificaSeAssinaturaExiste(usuario.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrada");

            _applicationContext.Usuarios.Update(usuario);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var usuario = await GetById(id);

            if (usuario == null)
                return 0;

            _applicationContext.Usuarios.Remove(usuario);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaId)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaId) != null;
        }
    }
}
