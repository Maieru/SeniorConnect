using Negocio.Model;
using Xunit;

namespace Negocio.Test.Repository.AssinaturaRepository
{
    public class AssinaturaRepositoryTest : BaseEntityTest<Negocio.Repository.AssinaturaRepository.AssinaturaRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var assinaturas = new List<AssinaturaModel>
            {
                new AssinaturaModel{ Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1},
                new AssinaturaModel{ Id = 2, DataCriacao = DateTime.UtcNow, PlanoId = 1},
                new AssinaturaModel{ Id = 3, DataCriacao = DateTime.UtcNow, PlanoId = 1}
            };
            _applicationContext.Assinaturas.AddRange(assinaturas);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(assinaturas, result);
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
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(assinatura, result);
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
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.Assinaturas);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            _applicationContext.Assinaturas.Add(assinatura);
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
            Assert.True(_applicationContext.Assinaturas.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Assinaturas.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var auxiliaryDate = DateTime.UtcNow.AddDays(-1);
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 1 };
            
            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();

            assinatura.DataCriacao = auxiliaryDate;

            // act
            var result = await _repository.Update(assinatura);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Assinaturas.Count() == 1);
            Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.DataCriacao == auxiliaryDate);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var assinaturaOriginal = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            _applicationContext.Assinaturas.Add(assinaturaOriginal);
            await _applicationContext.SaveChangesAsync();
            

            // act
            var assinaturaModificada = new AssinaturaModel { Id = 2, DataCriacao = DateTime.UtcNow, PlanoId = 2 };
            var result = await _repository.Update(assinaturaModificada);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Assinaturas.Count() == 1);
            Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.PlanoId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();

            var assinaturaModificada = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 2 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(assinaturaModificada));
            Assert.True(_applicationContext.Assinaturas.Count() == 1);
            Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.PlanoId == 1);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 1 };

            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(assinatura);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Assinaturas.Count() == 1);
            Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(assinatura));            
            Assert.True(_applicationContext.Assinaturas.Count() == 0);
        }
    }
}
