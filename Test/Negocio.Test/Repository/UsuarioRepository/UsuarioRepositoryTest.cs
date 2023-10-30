using Negocio.Helpers;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Repository.UsuarioRepository
{
    public class UsuarioRepositoryTest : BaseEntityTest<Negocio.Repository.Usuario.UsuarioRepository>
    {
        public UsuarioRepositoryTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Local");
            Environment.SetEnvironmentVariable("EncryptionWorkFactor", "4");
            Environment.SetEnvironmentVariable("EncryptionSalt", "Teste");
        }

        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var usuarios = new List<UsuarioModel>
            {
                new UsuarioModel{ Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1},
                new UsuarioModel{ Id = 2, Usuario = "2", Senha = "456", AssinaturaId = 1},
                new UsuarioModel{ Id = 3, Usuario = "3", Senha = "789", AssinaturaId = 1}
            };
            _applicationContext.Usuarios.AddRange(usuarios);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(usuarios, result);
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
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(usuario, result);
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
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.Usuarios);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Usuarios.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Usuarios.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Usuarios.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

            _applicationContext.Usuarios.Add(usuario);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Update(usuario);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Usuarios.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var usuarioOriginal = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

            _applicationContext.Usuarios.Add(usuarioOriginal);
            _applicationContext.Assinaturas.Add(assinatura);

            await _applicationContext.SaveChangesAsync();


            // act
            var usuarioModificado = new UsuarioModel { Id = 2, Usuario = "2", Senha = "456", AssinaturaId = 1 }; ;
            var result = await _repository.Update(usuarioModificado);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Usuarios.Count() == 1);
            Assert.True(_applicationContext.Usuarios.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

            _applicationContext.Usuarios.Add(usuario);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            var usuarioModificado = new UsuarioModel { Id = 2, Usuario = "2", Senha = "456", AssinaturaId = 1 };

            Assert.True(_applicationContext.Usuarios.Count() == 1);
            Assert.True(_applicationContext.Usuarios.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", SenhaPlain = "123", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };
            var senhaEncriptografada = await EncryptionHelper.Criptografa("123");

            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Insert(usuario);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Usuarios.Count() == 1);
            Assert.True(_applicationContext.Usuarios.FirstOrDefault()?.Id == 1);
            Assert.True(await EncryptionHelper.VerificaSenha("123", _applicationContext.Usuarios.FirstOrDefault()?.Senha));
            Assert.Null(usuario.SenhaPlain);            
        }

        [Fact]
        public async Task Insert_ShouldNotInsert_Assinatura()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", SenhaPlain = "123", AssinaturaId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(usuario));
            Assert.True(!_applicationContext.Usuarios.Any());
        }

        [Fact]
        public async Task Insert_ShouldNotInsert_Senha()
        {
            // arrange
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };
            var usuario = new UsuarioModel { Id = 1, Usuario = "1", Senha = "123", AssinaturaId = 1 };
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();
            
            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(usuario));
            Assert.True(!_applicationContext.Usuarios.Any());
        }

        [Fact]
        public async Task GetByUserAndPassword_ShouldReturn()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "Teste", Senha = await EncryptionHelper.Criptografa("123"), AssinaturaId = 1 };
            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetByUserAndPassword("Teste", "123");

            // assert
            Assert.NotNull(result);
            Assert.Equal(usuario, result);
        }

        [Fact]
        public async Task GetByUserAndPassword_ShouldNotReturn()
        {
            // act
            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.GetByUserAndPassword("Teste", await EncryptionHelper.Criptografa("123")));            
        }

        [Fact]
        public async Task GetByUserAndPassword_ShouldReturnNothing()
        {
            // arrange
            var usuario = new UsuarioModel { Id = 1, Usuario = "Teste", Senha = await EncryptionHelper.Criptografa("234"), AssinaturaId = 1 };
            _applicationContext.Usuarios.Add(usuario);
            await _applicationContext.SaveChangesAsync();

            // act
            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.GetByUserAndPassword("Teste", await EncryptionHelper.Criptografa("123")));
        }
    }
}
