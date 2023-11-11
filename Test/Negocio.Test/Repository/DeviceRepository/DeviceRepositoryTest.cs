using Microsoft.EntityFrameworkCore;
using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Repository.DeviceRepository
{
    public class DeviceRepositoryTest : BaseEntityTest<Negocio.Repository.Device.DeviceRepository>
    {
        [Fact]
        public async Task GetByIdentification_ShouldReturn()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            // act
            var dispositivo1 = await _repository.GetByIdentification(1, guids[0]);
            var dispositivo2 = await _repository.GetByIdentification(2, guids[1]);

            // assert
            Assert.Equal(devices[0], dispositivo1);
            Assert.Equal(devices[1], dispositivo2);
            Assert.IsAssignableFrom<PulseiraModel>(dispositivo1);
            Assert.IsAssignableFrom<CaixaRemedioModel>(dispositivo2);
            Assert.IsNotType<PulseiraModel>(dispositivo2);
            Assert.IsNotType<CaixaRemedioModel>(dispositivo1);
        }

        [Fact]
        public async Task GetByIdentification_ShouldNotReturn()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            // act
            var dispositivo1 = await _repository.GetByIdentification(2, guids[0]);
            var dispositivo2 = await _repository.GetByIdentification(1, guids[1]);
            var dispositivo3 = await _repository.GetByIdentification(0, null);

            // assert
            Assert.Null(dispositivo1);
            Assert.Null(dispositivo2);
            Assert.Null(dispositivo3);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldReturn()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devicesAssinatura1 = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            var devicesAssinatura2 = new List<IoTDeviceModel>
            {
                new CaixaRemedioModel {DeviceId = 3, DeviceKey = guids[2], AssinaturaId = 2, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.IoTDevices.AddRange(devicesAssinatura1);
            _applicationContext.IoTDevices.AddRange(devicesAssinatura2);
            await _applicationContext.SaveChangesAsync();

            // act
            var dispositivosAssinatura1 = await _repository.GetByAssinaturaId(1);
            var dispositivosAssinatura2 = await _repository.GetByAssinaturaId(2);

            // assert
            Assert.NotEmpty(dispositivosAssinatura1);
            Assert.NotEmpty(dispositivosAssinatura2);
            Assert.Contains(devicesAssinatura1[0], dispositivosAssinatura1);
            Assert.Contains(devicesAssinatura1[1], dispositivosAssinatura1);
            Assert.Contains(devicesAssinatura2[0], dispositivosAssinatura2);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldNotReturn()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            // act
            var dispositivosAssinatura2 = await _repository.GetByAssinaturaId(2);

            // assert
            Assert.Empty(dispositivosAssinatura2);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var newDescription = "Pulseira Atualizada";
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.Planos.Add(new PlanoModel() { Id = 1, Descricao = "Plano Teste", Valor = 59.99 });
            _applicationContext.Assinaturas.Add(new AssinaturaModel() { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 });
            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            devices[0].Descricao = newDescription;

            // act
            var result = await _repository.Update(devices[0]);

            Assert.True(result == 1);
            Assert.True(_applicationContext.IoTDevices.Count() == 2);
            Assert.Equal(newDescription, _applicationContext.IoTDevices.Where(d => d.DeviceId == 1).FirstOrDefault()?.Descricao);
            Assert.Equal(devices[1], _applicationContext.IoTDevices.Where(d => d.DeviceId == 2).FirstOrDefault());
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.Planos.Add(new PlanoModel() { Id = 1, Descricao = "Plano Teste", Valor = 59.99 });
            _applicationContext.Assinaturas.Add(new AssinaturaModel() { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 });
            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            var testDevice = new PulseiraModel { DeviceId = 3, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira };

            // act
            var result = await _repository.Update(testDevice);

            Assert.True(result == 0);
            Assert.True(_applicationContext.IoTDevices.Count() == 2);
            Assert.Equal("Pulseira", _applicationContext.IoTDevices.Where(d => d.DeviceId == 1).FirstOrDefault()?.Descricao);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.Planos.Add(new PlanoModel() { Id = 1, Descricao = "Plano Teste", Valor = 59.99 });
            _applicationContext.Assinaturas.Add(new AssinaturaModel() { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 });
            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            var testDevice = new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 2, Descricao = "Nova Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(testDevice));
            Assert.True(_applicationContext.IoTDevices.Count() == 2);
            Assert.True(_applicationContext.IoTDevices.Where(d => d.DeviceId == 1).FirstOrDefault()?.Descricao == "Pulseira");
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.Planos.Add(new PlanoModel() { Id = 1, Descricao = "Plano Teste", Valor = 59.99 });
            _applicationContext.Assinaturas.Add(new AssinaturaModel() { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 }); ;
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(devices[0]);

            Assert.True(result == 1);
            Assert.True(_applicationContext.IoTDevices.Count() == 1);
            Assert.True(_applicationContext.IoTDevices.FirstOrDefault() == devices[0]);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(devices[0]));
            Assert.True(_applicationContext.IoTDevices.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteWithAssociations()
        {
            // Arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            var lembrete = new LembreteModel { AssinaturaId = 1, Descricao = "Lembrete", Id = 1 };
            var medicamento = new MedicamentoModel { AssinaturaId = 1, Descricao = "Medicamento", Id = 1, PosicaoNaCaixaRemedio = 2 };

            var lembreteIoTDevice = new LembreteIoTDeviceModel { IoTDeviceId = 1, LembreteId = 1 };
            var medicamentoIoTDevice = new MedicamentoIoTDeviceModel { IoTDeviceId = 2, MedicamentoId = 1 };

            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Medicamentos.Add(medicamento);
            _applicationContext.LembreteIoTDevice.Add(lembreteIoTDevice);
            _applicationContext.MedicamentoIoTDevice.Add(medicamentoIoTDevice);

            await _applicationContext.SaveChangesAsync();

            // Act
            var resultDeletePulseira = await _repository.Delete(devices[0].DeviceId);
            var resultDeleteCaixaRemedio = await _repository.Delete(devices[1].DeviceId);

            // Assert
            Assert.Equal(2, resultDeletePulseira);
            Assert.Equal(2, resultDeleteCaixaRemedio);
            Assert.Empty(_applicationContext.IoTDevices);
            Assert.Empty(_applicationContext.LembreteIoTDevice);
            Assert.Empty(_applicationContext.MedicamentoIoTDevice);
            Assert.NotEmpty(_applicationContext.Lembretes);
            Assert.NotEmpty(_applicationContext.Medicamentos);
        }

        [Fact]
        public async Task Delete_WhenDeviceDoesNotExist_ShouldReturnZero()
        {
            // Arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            var lembrete = new LembreteModel { AssinaturaId = 1, Descricao = "Lembrete", Id = 1 };
            var medicamento = new MedicamentoModel { AssinaturaId = 1, Descricao = "Medicamento", Id = 1, PosicaoNaCaixaRemedio = 2 };

            var lembreteIoTDevice = new LembreteIoTDeviceModel { IoTDeviceId = 1, LembreteId = 1 };
            var medicamentoIoTDevice = new MedicamentoIoTDeviceModel { IoTDeviceId = 2, MedicamentoId = 1 };

            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Medicamentos.Add(medicamento);
            _applicationContext.LembreteIoTDevice.Add(lembreteIoTDevice);
            _applicationContext.MedicamentoIoTDevice.Add(medicamentoIoTDevice);

            await _applicationContext.SaveChangesAsync();

            // Act
            var result = await _repository.Delete(10);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task Delete_ShouldDeleteWithAssociationForOnlyOneDevice()
        {
            // Arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
                new PulseiraModel { DeviceId = 3, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
            };

            var lembrete = new LembreteModel { AssinaturaId = 1, Descricao = "Lembrete", Id = 1 };
            var medicamento = new MedicamentoModel { AssinaturaId = 1, Descricao = "Medicamento", Id = 1, PosicaoNaCaixaRemedio = 2 };

            var lembreteIoTDevice1 = new LembreteIoTDeviceModel { IoTDeviceId = 1, LembreteId = 1 };
            var lembreteIoTDevice2 = new LembreteIoTDeviceModel { IoTDeviceId = 3, LembreteId = 1 };
            var medicamentoIoTDevice = new MedicamentoIoTDeviceModel { IoTDeviceId = 2, MedicamentoId = 1 };

            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Medicamentos.Add(medicamento);
            _applicationContext.LembreteIoTDevice.Add(lembreteIoTDevice1);
            _applicationContext.LembreteIoTDevice.Add(lembreteIoTDevice2);
            _applicationContext.MedicamentoIoTDevice.Add(medicamentoIoTDevice);

            await _applicationContext.SaveChangesAsync();

            // Act
            var resultDeletePulseira = await _repository.Delete(devices[0].DeviceId);
            
            // Assert
            Assert.Equal(2, resultDeletePulseira);
            Assert.NotEmpty(_applicationContext.IoTDevices);
            Assert.Equal(2, _applicationContext.IoTDevices.Count());
            Assert.NotEmpty(_applicationContext.LembreteIoTDevice);
            Assert.Equal(1, _applicationContext.LembreteIoTDevice.Count());
            Assert.Equal(lembreteIoTDevice2, _applicationContext.LembreteIoTDevice.FirstOrDefault());
            Assert.NotEmpty(_applicationContext.MedicamentoIoTDevice);
            Assert.NotEmpty(_applicationContext.Lembretes);
            Assert.NotEmpty(_applicationContext.Medicamentos);
        }
    }
}
