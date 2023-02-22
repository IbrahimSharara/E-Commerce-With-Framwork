using E_Commerce.DAL;
using E_Commerce.VM.ViewModels;
using E_Commerce.WebUI.Models;
using ECommerce.BLL.Interfaces;
using ECommerce.BLL.Srevices;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryRepository Repo = new CategoryRepository();
        //public CategoryController(ICategoryRepository repo)
        //{
        //    Repo = repo;
        //}

        #region Show All Categories
        public async Task<ActionResult> Index()
        {
            var cat = await Repo.GetAll();
            return View(cat);
        }
        #endregion

        #region Add New Category
        public ActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryVM modle)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.result = "Error";
                return PartialView("_Add" , modle);
            }
            Category newCat = new Category
            {
                Name = modle.Name,
                Description = modle.Description
            };
            int result = await Repo.Add(newCat);
            if (result > 0)
                ViewBag.result = "inserted successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete Category
        public async Task<ActionResult> Delete(int id)
        {
            var c = await Repo.GetById(id);
            Repo.Delete(c);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details of Category
        public async Task<ActionResult> Details(int id)
        {
            var c = await Repo.GetById(id);
            CategoryVM details = new CategoryVM
            {
                Name = c.Name,
                Description = c.Description,
            };
            return PartialView("_Details", details);
        }
        #endregion

        #region Update Category
        public async Task<ActionResult> Update(int id)
        {
            Category cat = await Repo.GetById(id);
            CategoryVM cVM = new CategoryVM
            {
                Name = cat.Name,
                Description = cat.Description,
            };
            return View("_Update", cVM);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id, CategoryVM vm)
        {
            Category c = new Category
            {
                Name = vm.Name,
                ID = vm.ID,
                Description = vm.Description
            };
            int result = Repo.UpdateCategory(id, c);
            if (result > 0)
            {
                ViewBag.result = "Error";
            }
            else
                ViewBag.result = "Error";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Get All and return json
        public async Task<ActionResult> GetAllJson()
        {
            var cat = await Repo.GetAll();
            return Json(cat, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}