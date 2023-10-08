using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.LembreteRepository
{
    public interface ILembreteRepository
    {
        Task<List<LembreteModel>> GetLembretesByDevice(IoTDeviceModel device);
    }
}
