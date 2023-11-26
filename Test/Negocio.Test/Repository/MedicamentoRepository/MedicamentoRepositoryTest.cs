using Negocio.Enum;
using Negocio.Model;
using Negocio.Model.Device;
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
        public async Task GetById_ShouldReturnAssociations()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var device = new CaixaRemedioModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = EnumDeviceType.CaixaRemedio };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var deviceMedicamento = new MedicamentoIoTDeviceModel { Id = 1, IoTDeviceId = 1, MedicamentoId = 1 };

            _applicationContext.MedicamentoIoTDevice.Add(deviceMedicamento);
            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.IoTDevices.Add(device);
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.DispositivosAssociados);
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
            Assert.True(_applicationContext.Usuarios.Count() == 0);
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
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 };

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
        public async Task Update_ShouldUpdateWithDeviceAssociation()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var device = new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.Medicamentos.Add(medicamento);
            _applicationContext.IoTDevices.Add(device);
            await _applicationContext.SaveChangesAsync();

            medicamento.DispositivosAssociados = new List<int>() { 1 };

            // act
            await _repository.Update(medicamento);

            Assert.True(_applicationContext.Medicamentos.FirstOrDefault() == medicamento);
            Assert.NotEmpty(_applicationContext.MedicamentoIoTDevice);
        }

        [Fact]
        public async Task Insert_ShouldNotUpdateWithDeviceAssociation()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            medicamento.DispositivosAssociados = new List<int>() { 1 };

            // act
            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(medicamento));
            Assert.Empty(_applicationContext.LembreteIoTDevice);
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

        [Fact]
        public async Task Insert_ShouldInsertWithDeviceAssociation()
        {
            // arrange
            var device = new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira };
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1, DispositivosAssociados = new List<int> { 1 } };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.IoTDevices.Add(device);
            await _applicationContext.SaveChangesAsync();

            // arrange
            await _repository.Insert(medicamento);

            Assert.True(_applicationContext.Medicamentos.FirstOrDefault() == medicamento);
            Assert.NotEmpty(_applicationContext.MedicamentoIoTDevice);
        }

        [Fact]
        public async Task Insert_ShouldNotInsertWithDeviceAssociation()
        {
            // arrange
            var medicamento = new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1, DispositivosAssociados = new List<int> { 1 } };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(medicamento));
            Assert.Empty(_applicationContext.LembreteIoTDevice);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldReturn()
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
            var result = await _repository.GetByAssinaturaId(1);

            // assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(medicamentos[0], result[0]);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldNotReturn()
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
            var result = await _repository.GetByAssinaturaId(4);

            // assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetByDevice_ShouldReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel{ Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1},
                new MedicamentoModel{ Id = 2, AssinaturaId = 2, Descricao = "2", PosicaoNaCaixaRemedio = 2},
                new MedicamentoModel{ Id = 3, AssinaturaId = 3, Descricao = "3", PosicaoNaCaixaRemedio = 3}
            };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
            };

            var associacoesMedicamentoDevice = new List<MedicamentoIoTDeviceModel>
            {
                new MedicamentoIoTDeviceModel { Id = 1, MedicamentoId = 1, IoTDeviceId = 1 },
                new MedicamentoIoTDeviceModel { Id = 2, MedicamentoId = 3, IoTDeviceId = 1 },
                new MedicamentoIoTDeviceModel { Id = 3, MedicamentoId = 1, IoTDeviceId = 2 },
            };

            _applicationContext.Medicamentos.AddRange(medicamentos);
            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.MedicamentoIoTDevice.AddRange(associacoesMedicamentoDevice);
            await _applicationContext.SaveChangesAsync();

            // act
            var medicamentosDevice1 = await _repository.GetByDevice(devices[0]);
            var medicamentosDevice2 = await _repository.GetByDevice(devices[1]);

            // assert
            Assert.NotNull(medicamentosDevice1);
            Assert.Equal(2, medicamentosDevice1.Count());
            Assert.Equal(medicamentos[0], medicamentosDevice1[0]);
            Assert.Equal(medicamentos[2], medicamentosDevice1[1]);

            Assert.NotNull(medicamentosDevice2);
            Assert.Single(medicamentosDevice2);
            Assert.Equal(medicamentos[0], medicamentosDevice2[0]);
        }

        [Fact]
        public async Task GetByDevice_ShouldNotReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel{ Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1},
                new MedicamentoModel{ Id = 2, AssinaturaId = 2, Descricao = "2", PosicaoNaCaixaRemedio = 2},
                new MedicamentoModel{ Id = 3, AssinaturaId = 3, Descricao = "3", PosicaoNaCaixaRemedio = 3}
            };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
            };

            var associacoesMedicamentoDevice = new List<MedicamentoIoTDeviceModel>
            {
                new MedicamentoIoTDeviceModel { Id = 1, MedicamentoId = 1, IoTDeviceId = 1 },
                new MedicamentoIoTDeviceModel { Id = 2, MedicamentoId = 3, IoTDeviceId = 1 },
            };

            _applicationContext.Medicamentos.AddRange(medicamentos);
            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.MedicamentoIoTDevice.AddRange(associacoesMedicamentoDevice);
            await _applicationContext.SaveChangesAsync();

            // act
            var medicamentosDevice = await _repository.GetByDevice(devices[1]);

            // assert
            Assert.NotNull(medicamentosDevice);
            Assert.Empty(medicamentosDevice);
        }

        [Fact]
        public async Task GetDevicesAssociated_ShouldReturnListOfInt_WhenMedicamentoIdIsValid()
        {
            // Arrange
            var medicamentoId = 1;
            var device = new CaixaRemedioModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = EnumDeviceType.CaixaRemedio };
            var medicamento = new MedicamentoModel { Id = 1, PosicaoNaCaixaRemedio = 2, Descricao = "abc", AssinaturaId = 1, DispositivosAssociados = new List<int>() { 1 } };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var medicamentoIotDevice = new List<MedicamentoIoTDeviceModel>
            {
                new MedicamentoIoTDeviceModel { IoTDeviceId = 1, MedicamentoId = 1},
                new MedicamentoIoTDeviceModel { IoTDeviceId = 2, MedicamentoId = 1},
                new MedicamentoIoTDeviceModel { IoTDeviceId = 3, MedicamentoId = 1}
            };
            var expected = medicamentoIotDevice.Select(l => l.IoTDeviceId).ToList();
            _applicationContext.MedicamentoIoTDevice.AddRange(medicamentoIotDevice);
            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.IoTDevices.Add(device);
            await _applicationContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetDevicesAssociated(medicamentoId);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetDevicesAssociated_ShouldReturnEmptyList_WhenMedicamentoIdIsInvalid()
        {
            // Arrange
            var medicamentoId = 1;
            var expected = new List<int>();

            // Act
            var result = await _repository.GetDevicesAssociated(medicamentoId);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
