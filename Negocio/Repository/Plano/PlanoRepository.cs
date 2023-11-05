using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Plano
{
    public class PlanoRepository : BaseEntityRepository, IPlanoRepository
    {
        public PlanoRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<PlanoModel>> GetAll() => await _applicationContext.Planos.ToListAsync();

        public async Task<PlanoModel?> GetById(int id) => await _applicationContext.Planos.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> Delete(int id)
        {
            var plano = await GetById(id);

            if (plano == null)
                return 0;

            _applicationContext.Planos.Remove(plano);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(PlanoModel plano)
        {
            await _applicationContext.Planos.AddAsync(plano);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(PlanoModel plano)
        {
            if (!await _applicationContext.Planos.AnyAsync(p => p.Id == plano.Id))
                return 0;

            _applicationContext.Planos.Update(plano);
            return await _applicationContext.SaveChangesAsync();
        }
    }
}
