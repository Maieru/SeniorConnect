using Negocio.Model;
using Xunit;

namespace Negocio.Test.Repository.LembreteRepository
{
    public class LembreteMedicamentoRepositoryTest : BaseEntityTest<Negocio.Repository.LembreteMedicamento.LembreteMedicamentoRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var lembreteMedicamento = new List<LembreteMedicamentoModel>
        {
            new LembreteMedicamentoModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
            new LembreteMedicamentoModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
            new LembreteMedicamentoModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 }
        };
            _applicationContext.LembreteMedicamentos.AddRange(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(lembreteMedicamento, result);
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
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(lembreteMedicamento, result);
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
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.LembreteMedicamentos);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var auxiliaryDate = DateTime.UtcNow.AddDays(-1);
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var medicamento = new MedicamentoModel { Id = 1, PosicaoNaCaixaRemedio = 1, Descricao = "abc", AssinaturaId = 1 };

            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            lembreteMedicamento.Horario = auxiliaryDate;

            // act
            var result = await _repository.Update(lembreteMedicamento);

            Assert.True(result == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.Horario == auxiliaryDate);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var lembreteMedicamentoOriginal = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamentoOriginal);
            await _applicationContext.SaveChangesAsync();


            // act
            var lembreteMedicamentoModificado = new LembreteMedicamentoModel { Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var result = await _repository.Update(lembreteMedicamentoModificado);

            Assert.True(result == 0);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.MedicamentoId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var medicamento = new MedicamentoModel { Id = 2, PosicaoNaCaixaRemedio = 1, Descricao = "abc", AssinaturaId = 1 };

            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            var lembreteMedicamentoModificado = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(lembreteMedicamentoModificado));
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.MedicamentoId == 1);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var medicamento = new MedicamentoModel { Id = 1, PosicaoNaCaixaRemedio = 1, Descricao = "abc", AssinaturaId = 1 };

            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(lembreteMedicamento);

            Assert.True(result == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(lembreteMedicamento));
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 0);
        }
    }
}
