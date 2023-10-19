using Negocio.Database;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Repository.PlanoRepository
{
    public class PlanoRepositoryTest : BaseEntityTest<Negocio.Repository.Plano.PlanoRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var planos = new List<PlanoModel>
            {
                new PlanoModel{ Id = 1, Descricao = "Test 1", Valor = 1},
                new PlanoModel{ Id = 2, Descricao = "Test 2", Valor = 12.9},
                new PlanoModel{ Id = 3, Descricao = "Test 3", Valor = 123.23}
            };
            _applicationContext.Planos.AddRange(planos);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(planos, result);
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
            var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 1 };
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(plano, result);
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
            var plano = new PlanoModel { Id = 2, Descricao = "Test 2", Valor = 12.9 };
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.Planos);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var plano = new PlanoModel { Id = 2, Descricao = "Test 2", Valor = 12.9 };
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Planos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Planos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var plano = new PlanoModel { Id = 2, Descricao = "Test 2", Valor = 12.9 };
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Planos.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var plano = new PlanoModel { Id = 2, Descricao = "Test 2", Valor = 12.9 };
            _applicationContext.Planos.Add(plano);
            await _applicationContext.SaveChangesAsync();
            plano.Valor = 12.999;

            // act
            var result = await _repository.Update(plano);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Planos.Count() == 1);
            Assert.True(_applicationContext.Planos.FirstOrDefault()?.Valor == 12.999);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var planoOriginal = new PlanoModel { Id = 2, Descricao = "Test 2", Valor = 12.9 };
            _applicationContext.Planos.Add(planoOriginal);
            await _applicationContext.SaveChangesAsync();

            // act
            var planoModificada = new PlanoModel { Id = 3, Descricao = "Test 3", Valor = 12.99899 };
            var result = await _repository.Update(planoModificada);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Planos.Count() == 1);
            Assert.True(_applicationContext.Planos.FirstOrDefault()?.Valor == 12.9);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 11.5 };

            // act
            var result = await _repository.Insert(plano);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Planos.Count() == 1);
            Assert.True(_applicationContext.Planos.FirstOrDefault()?.Id == 1);
            Assert.True(_applicationContext.Planos.FirstOrDefault()?.Valor == 11.5);
        }
    }
}
