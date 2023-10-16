using Negocio.Model;
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
        Task<IEnumerable<IoTDeviceModel>> GetAll();
        Task<IoTDeviceModel> GetByAssinaturaId(int assinaturaId);
        Task<int> Insert(IoTDeviceModel assinatura);
        Task<int> Update(IoTDeviceModel assinatura);
        Task<int> Delete(int id);
    }
}
