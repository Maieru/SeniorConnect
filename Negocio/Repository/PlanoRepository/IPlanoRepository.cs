using Negocio.Model;

namespace Negocio.Repository.PlanoRepository
{
    public interface IPlanoRepository
    {
        Task<IEnumerable<PlanoModel>> GetAll();
        Task<PlanoModel> GetById(int id);
        Task<int> Insert(PlanoModel plano);
        Task<int> Update(PlanoModel plano);
        Task<int> Delete(int id);
    }
}
