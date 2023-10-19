using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Lembrete
{
    public class LembreteRepository : BaseEntityRepository, ILembreteRepository
    {
        public LembreteRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<List<LembreteModel>> GetLembretesByDevice(IoTDeviceModel device)
        {
            // TODO: Implementar
            // ATENÇÃO: LEMBRAR QUE O CAMPO DE "POSICAO NA CAIXA DE REMÉDIO" EXISTE E AFETA A ORDEM NA QUAL OS AGENDAMENTOS SÃO ENVIADOS
            var random = new Random();

            return new List<LembreteModel>
            {
                new LembreteModel(){ Id = 1, AssinaturaId = 1, Descricao = "Tomar aqua líquida", Horario = DateTime.UtcNow.AddHours(random.Next(12)) },
                new LembreteModel(){ Id = 2, AssinaturaId = 1, Descricao = "Comer aquele prato saboroso de comida", Horario = DateTime.UtcNow.AddMinutes(random.Next(960)) },
                new LembreteModel(){ Id = 3, AssinaturaId = 1, Descricao = "Fazer os 20km diário de esteira", Horario = DateTime.UtcNow.AddMinutes(random.Next(960)) },
                new LembreteModel(){ Id = 4, AssinaturaId = 1, Descricao = "Fofocar com as amiguinhas", Horario = DateTime.UtcNow.AddMinutes(random.Next(960)) },
                new LembreteModel(){ Id = 5, AssinaturaId = 1, Descricao = "Tomar (mais) aqua líquida", Horario = DateTime.UtcNow.AddMinutes(random.Next(960)) },
            };
        }

        public async Task<IEnumerable<LembreteModel>> GetAll() => await _applicationContext.Lembretes.ToListAsync();

        public async Task<LembreteModel?> GetById(int id) => await _applicationContext.Lembretes.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> Delete(int id)
        {
            var lembrete = await GetById(id);

            if (lembrete == null)
                return 0;

            _applicationContext.Lembretes.Remove(lembrete);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(LembreteModel lembrete)
        {
            if (!await VerificaSeAssinaturaExiste(lembrete.AssinaturaId))
                throw new ArgumentException("Novo plano não encontrado");

            await _applicationContext.Lembretes.AddAsync(lembrete);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(LembreteModel lembrete)
        {
            if (await GetById(lembrete.Id) == null)
                return 0;

            if (!await VerificaSeAssinaturaExiste(lembrete.AssinaturaId))
                throw new ArgumentException("Novo plano não encontrado");

            _applicationContext.Lembretes.Update(lembrete);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaid)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaid) != null;
        }
    }
}
