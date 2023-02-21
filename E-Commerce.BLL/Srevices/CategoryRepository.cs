using E_Commerce.DAL;
using ECommerce.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ECommerce.BLL.Srevices
{
    public class CategoryRepository : GeneralRepository<Category>, ICategoryRepository
    {
        //public CategoryRepository(ECommerceEntities db) : base(db)
        //{
        //}

        public Category GetCategoryByName(string name)
        {
            return Db.Categories.SingleOrDefault(c => c.Name == name);
        }

        public int UpdateCategory(int id, Category category)
        {
            Category check = GetCategoryByName(category.Name);
            if (check != null)
            {
                if (check.ID == category.ID && check.Description != category.Description)
                {
                    check.Description = category.Description;
                    return Db.SaveChanges();
                }
                return -1;
            }
            else
            {
                Category old = Db.Categories.Find(category.ID);
                if (old is null || old.ID != id)
                {
                    return -1;
                }
                old.Description = category.Description;
                old.Name = category.Name;
                return Db.SaveChanges();
            }
        }
    }
}
