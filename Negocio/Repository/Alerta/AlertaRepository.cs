using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Repository.Plano;
using Negocio.Repository.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Alerta
{
    public class AlertaRepository : BaseEntityRepository, IAlertaRepository
    {
        public AlertaRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<AlertaModel>> GetAll() => await _applicationContext.Alertas.ToListAsync();

        public async Task<int> Insert(AlertaModel alerta)
        {
            if (!await VerificaSeUsuarioExiste(alerta.IdUsuario))
                throw new ArgumentException("Usuário não existe");

            await _applicationContext.Alertas.AddAsync(alerta);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var alerta = await _applicationContext.Alertas.FirstOrDefaultAsync(a => a.Id == id);

            if (alerta == null)
                return 0;

            _applicationContext.Alertas.Remove(alerta);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeUsuarioExiste(int usuarioId)
        {
            var usuarioRepository = new UsuarioRepository(_applicationContext);
            return await usuarioRepository.GetById(usuarioId) != null;
        }
    }
}
