using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interfaces
{
    public interface IGeneralRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        int Delete(T t);
        Task<int> Add(T t);
    }
}
