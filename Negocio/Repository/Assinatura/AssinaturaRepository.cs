using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Assinatura
{
    public class AssinaturaRepository : BaseEntityRepository, IAssinaturaRepository
    {
        public AssinaturaRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<AssinaturaModel>> GetAll() => await _applicationContext.Assinaturas.ToListAsync();

        public async Task<AssinaturaModel?> GetById(int id) => await _applicationContext.Assinaturas.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> Delete(int id)
        {
            var assinatura = await GetById(id);

            if (assinatura == null)
                return 0;

            _applicationContext.Assinaturas.Remove(assinatura);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(AssinaturaModel assinatura)
        {
            if (!await VerificaSePlanoExiste(assinatura.PlanoId))
                throw new ArgumentException("Novo plano não encontrado");

            await _applicationContext.Assinaturas.AddAsync(assinatura);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(AssinaturaModel assinatura)
        {
            if (!await _applicationContext.Assinaturas.AnyAsync(a => a.Id == assinatura.Id))
                return 0;

            if (!await VerificaSePlanoExiste(assinatura.PlanoId))
                throw new ArgumentException("Novo plano não encontrado");

            _applicationContext.Assinaturas.Update(assinatura);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSePlanoExiste(int planoId)
        {
            var planoRepository = new PlanoRepository(_applicationContext);
            return await planoRepository.GetById(planoId) != null;
        }
    }
}
