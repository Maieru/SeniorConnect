using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Model;
using Negocio.Model.Device;
using Negocio.Repository.Medicamento;
using Negocio.Repository.Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.LembreteMedicamento
{
    public class LembreteMedicamentoRepository : BaseEntityRepository, ILembreteMedicamentoRepository
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

        public async Task<IEnumerable<LembreteMedicamentoModel>> GetAll() => await _applicationContext.LembreteMedicamentos.ToListAsync();

        public async Task<LembreteMedicamentoModel?> GetById(int id) => await _applicationContext.LembreteMedicamentos.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> Delete(int id)
        {
            var lembreteMedicamento = await GetById(id);

            if (lembreteMedicamento == null)
                return 0;

            _applicationContext.LembreteMedicamentos.Remove(lembreteMedicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Insert(LembreteMedicamentoModel lembreteMedicamento)
        {
            if (!await VerificaSeMedicamentoExiste(lembreteMedicamento.MedicamentoId))
                throw new ArgumentException("Novo plano não encontrado");

            await _applicationContext.LembreteMedicamentos.AddAsync(lembreteMedicamento);
            return await _applicationContext.SaveChangesAsync();

        }

        public async Task<int> Update(LembreteMedicamentoModel lembreteMedicamento)
        {
            if (await GetById(lembreteMedicamento.Id) == null)
                return 0;

            if (!await VerificaSeMedicamentoExiste(lembreteMedicamento.MedicamentoId))
                throw new ArgumentException("Novo plano não encontrado");

            _applicationContext.LembreteMedicamentos.Update(lembreteMedicamento);
            return await _applicationContext.SaveChangesAsync();
        }

        private async Task<bool> VerificaSeMedicamentoExiste(int medicamentoId)
        {
            var MedicamentoRepository = new MedicamentoRepository(_applicationContext);
            return await MedicamentoRepository.GetById(medicamentoId) != null;        
        }
    }
}