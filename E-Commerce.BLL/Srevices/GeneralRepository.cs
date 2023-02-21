using E_Commerce.DAL;
using ECommerce.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.BLL.Srevices
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {

        public ECommerceEntities Db = new ECommerceEntities();
        //public GeneralRepository(ECommerceEntities db )
        //{
        //    Db = db;
        //}

        #region Add new Item
        public async Task<int> Add(T t)
        {
            Db.Set<T>().Add(t);
            return await Db.SaveChangesAsync();
        }
        #endregion
        #region Remove 
        public int Delete(T t)
        {
            Db.Set<T>().Remove(t);
            return Db.SaveChanges();
        }
        #endregion
        #region GetALl
        public async Task<List<T>> GetAll()
        {
            return Db.Set<T>().ToList();
        }
        #endregion
        #region Get by id
        public async Task<T> GetById(int id)
        {
            return await Db.Set<T>().FindAsync(id);
        }
        #endregion 
    }
}
