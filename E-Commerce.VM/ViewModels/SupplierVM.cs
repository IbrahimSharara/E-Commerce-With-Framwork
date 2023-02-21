using E_Commerce.DAL;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.VM.ViewModels
{
    public class SupplierVM : Supplier
    {
        [Required]
        [MaxLength(100 , ErrorMessage ="Please enter Valid name")]
        public string SupplierName { get; set; }
    }
}
