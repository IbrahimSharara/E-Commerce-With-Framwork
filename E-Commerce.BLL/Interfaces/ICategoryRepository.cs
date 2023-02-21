using E_Commerce.DAL;
using System.Collections.Generic;

namespace ECommerce.BLL.Interfaces
{
    public interface ICategoryRepository : IGeneralRepository<Category>
    {
        Category GetCategoryByName(string name);
        int UpdateCategory(int id , Category category);
    }
}
