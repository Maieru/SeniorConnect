using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Medicamento
{
    public interface IMedicamentoRepository
    {
        Task<List<MedicamentoModel>> GetByAssinaturaId(int assinaturaId);
        Task<List<MedicamentoModel>> GetByDevice(IoTDeviceModel device);
        Task<IEnumerable<MedicamentoModel>> GetAll();
        Task<MedicamentoModel> GetById(int id);
        Task<int> Insert(MedicamentoModel medicamento);
        Task<int> Update(MedicamentoModel medicamento);
        Task<int> Delete(int id);
    }
}