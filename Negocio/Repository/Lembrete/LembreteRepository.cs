using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
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
    }
}
