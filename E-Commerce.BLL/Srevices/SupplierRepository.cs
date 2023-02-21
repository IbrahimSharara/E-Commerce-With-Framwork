using E_Commerce.DAL;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Srevices;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.BLL.Srevices
{
    public class SupplierRepository : GeneralRepository<Supplier>, ISupplierRepository
    {
        public List<Supplier> GetCategoryByName(string name)
        {
            return Db.Suppliers.Where(c => c.SupplierName == name).ToList();
        }

        public int UpdateSupplier(int id, Supplier Supplier)
        {
            Supplier old = Db.Suppliers.Find(Supplier.SupplierID);
            if (old is null || old.SupplierID != id)
            {
                return -1;
            }
            old.SupplierName = Supplier.SupplierName;
            return Db.SaveChanges();
        }
    }
}
