using Negocio.Model;
using Xunit;

namespace Negocio.Test.Repository.LembreteRepository
{
    public class LembreteRepositoryTest : BaseEntityTest<Negocio.Repository.Lembrete.LembreteRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var lembretes = new List<LembreteModel>
        {
            new LembreteModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
            new LembreteModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
            new LembreteModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 }
        };
            _applicationContext.Lembretes.AddRange(lembretes);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(lembretes, result);
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
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(lembrete, result);
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
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.Lembretes);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Lembretes.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Lembretes.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var auxiliaryDate = DateTime.UtcNow.AddDays(-1);
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            lembrete.Horario = auxiliaryDate;

            // act
            var result = await _repository.Update(lembrete);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.Horario == auxiliaryDate);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var lembreteOriginal = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembreteOriginal);
            await _applicationContext.SaveChangesAsync();


            // act
            var lembreteModificado = new LembreteModel { Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var result = await _repository.Update(lembreteModificado);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 2, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            var lembreteModificado = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(lembreteModificado));
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(lembrete);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(lembrete));
            Assert.True(_applicationContext.Lembretes.Count() == 0);
        }
    }
}
