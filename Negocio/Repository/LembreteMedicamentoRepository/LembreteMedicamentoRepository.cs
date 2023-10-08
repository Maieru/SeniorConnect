using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.LembreteMedicamentoRepository
{
    public class LembreteMedicamentoRepository : BaseRepository, ILembreteMedicamentoRepository
    {
        public LembreteMedicamentoRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<List<LembreteMedicamentoModel>> GetLembretesMedicamentoByDevice(IoTDeviceModel device)
        {
            // TODO: Implementar
            // ATENÇÃO: LEMBRAR QUE O CAMPO DE "POSICAO NA CAIXA DE REMÉDIO" EXISTE E AFETA A ORDEM NA QUAL OS AGENDAMENTOS SÃO ENVIADOS
            var random = new Random();

            return new List<LembreteMedicamentoModel>
            {
                null,
                null,
                new LembreteMedicamentoModel
                {
                    Descricao = "Dipirona",
                    Horario = DateTime.UtcNow.AddHours(random.Next(12)),
                    MedicamentoId = 1,
                    Id = 1
                },
                new LembreteMedicamentoModel
                {
                    Descricao = "Rivotril",
                    Horario = DateTime.UtcNow.AddHours(random.Next(24)).AddMinutes(random.Next(50)),
                    MedicamentoId = 2,
                    Id = 2
                },
                new LembreteMedicamentoModel
                {
                    Descricao = "Benegripe",
                    Horario = DateTime.UtcNow.AddHours(random.Next(24)).AddMinutes(random.Next(50)),
                    MedicamentoId = 3,
                    Id = 3
                },
                null,
                null
            };
        }
    }
}
