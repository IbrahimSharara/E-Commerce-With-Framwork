using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Interfaces
{
    public interface ISupplierRepository :IGeneralRepository<Supplier>
    {
        List<Supplier> GetCategoryByName(string name);
        int UpdateSupplier(int id, Supplier Supplier);
    }
}
