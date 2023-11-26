using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Device
{
    public interface IDeviceRepository
    {
        Task<IoTDeviceModel> GetByIdentification(int deviceId, string deviceKey);
        Task<List<IoTDeviceModel>> GetByAssinaturaId(int assinaturaId);
        Task<int> Insert(IoTDeviceModel device);
        Task<int> Update(IoTDeviceModel device);
        Task<int> Delete(int id);
        Task<int> GetUsuarioAssociatedWithDevice(int deviceId, string deviceKey);
    }
}
