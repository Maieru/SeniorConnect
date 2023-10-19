using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Repository.MedicamentoRepository
{
    public class MedicamentoRepositoryTest : BaseEntityTest<Negocio.Repository.Medicamento.MedicamentoRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel{ Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1},
                new MedicamentoModel{ Id = 2, AssinaturaId = 2, Descricao = "2", PosicaoNaCaixaRemedio = 2},
                new MedicamentoModel{ Id = 3, AssinaturaId = 3, Descricao = "3", PosicaoNaCaixaRemedio = 3}
            };
            _applicationContext.Medicamentos.AddRange(medicamentos);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(medicamentos, result);
        }

        [Fact]
        public async Task GetAll_ShouldNotReturn()
        {
            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_ShouldReturn()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(medicamento, result);
        }

        [Fact]
        public async Task GetById_ShouldNotReturn()
        {
            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnNothing()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.Medicamentos);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Assinaturas.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Medicamentos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Medicamentos.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var auxiliaryDate = DateTime.UtcNow.AddDays(-1);
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1};

            _applicationContext.Medicamentos.Add(medicamento);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Update(medicamento);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Medicamentos.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var medicamentoOriginal = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

            _applicationContext.Medicamentos.Add(medicamentoOriginal);
            _applicationContext.Assinaturas.Add(assinatura);

            await _applicationContext.SaveChangesAsync();

            
            // act
            var medicamentoModificado = new MedicamentoModel { Id = 2, AssinaturaId = 1, Descricao = "2", PosicaoNaCaixaRemedio = 2 };
            var result = await _repository.Update(medicamentoModificado);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Medicamentos.Count() == 1);
            Assert.True(_applicationContext.Medicamentos.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

            _applicationContext.Medicamentos.Add(medicamento);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            var medicamentoModificado = new MedicamentoModel { Id = 2, AssinaturaId = 1, Descricao = "2", PosicaoNaCaixaRemedio = 1 };

            Assert.True(_applicationContext.Medicamentos.Count() == 1);
            Assert.True(_applicationContext.Medicamentos.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(medicamento);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Medicamentos.Count() == 1);
            Assert.True(_applicationContext.Medicamentos.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(medicamento));
            Assert.True(_applicationContext.Medicamentos.Count() == 0);
        }
    }
}
