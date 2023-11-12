using Negocio.Enum;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Repository.AlertaRepository
{
    public class AssinaturaRepositoryTest : BaseEntityTest<Negocio.Repository.Alerta.AlertaRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var alertas = new List<AlertaModel>
            {
                new AlertaModel{ Id = 1, Data = DateTime.UtcNow, IdUsuario = 1, TipoAlerta = EnumTipoAlerta.BotaoEmergencia},
                new AlertaModel{ Id = 2, Data = DateTime.UtcNow, IdUsuario = 1, TipoAlerta = EnumTipoAlerta.Queda},
                new AlertaModel{ Id = 3, Data = DateTime.UtcNow, IdUsuario = 1, TipoAlerta = EnumTipoAlerta.IgnorarRemedio}
            };
            _applicationContext.Alertas.AddRange(alertas);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(alertas, result);
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
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var usuario = new UsuarioModel() { Id = 1, Senha = "123", Email = "teste", Usuario = "teste" };
            var alerta = new AlertaModel { Id = 1, Data = DateTime.UtcNow, IdUsuario = 1, TipoAlerta = EnumTipoAlerta.BotaoEmergencia };

            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Insert(alerta);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Alertas.Count() == 1);
            Assert.True(_applicationContext.Alertas.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var alerta = new AlertaModel { Id = 1, Data = DateTime.UtcNow, IdUsuario = 1, TipoAlerta = EnumTipoAlerta.BotaoEmergencia };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(alerta));
            Assert.True(_applicationContext.Assinaturas.Count() == 0);
        }
    }
}
