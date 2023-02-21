using E_Commerce.DAL;
using System.ComponentModel.DataAnnotations;
namespace E_Commerce.VM.ViewModels
{
    public class CategoryVM : Category
    {
        [Required]
        [StringLength(100 , ErrorMessage ="Please enter valid name")]
        public string Name { get; set; }
    }
}
