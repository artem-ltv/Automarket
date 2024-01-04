using System.Threading.Tasks;

namespace Automarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<bool> Delete(int id);
    }
}
