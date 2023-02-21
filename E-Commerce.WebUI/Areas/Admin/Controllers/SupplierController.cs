using E_Commerce.BLL.Srevices;
using E_Commerce.DAL;
using E_Commerce.VM.ViewModels;
using ECommerce.BLL.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        public ISupplierRepository Repo = new SupplierRepository();
        //public SupplierController(ISupplierRepository repo)
        //{
        //    Repo = repo;
        //}

        #region Show All Suppliers
        public async Task<ActionResult> Index()
        {
            var cat = await Repo.GetAll();
            return View(cat);
        }
        #endregion

        #region Add New Supplier
        public ActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public async Task<ActionResult> Add(SupplierVM modle)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.result = "Error";
                return RedirectToAction(nameof(Index));
            }

            Supplier newCat = new Supplier
            {
                SupplierName = modle.SupplierName,
            };
            int result = await Repo.Add(newCat);
            if (result > 0)
                ViewBag.result = "inserted successfully";
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete Supplier
        public async Task<ActionResult> Delete(int id)
        {
            var c = await Repo.GetById(id);
            Repo.Delete(c);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details of Supplier
        public async Task<ActionResult> Details(int id)
        {
            var c = await Repo.GetById(id);
            SupplierVM details = new SupplierVM
            {
                SupplierName = c.SupplierName,
            };
            return PartialView("_Details", details);
        }
        #endregion

        #region Update Supplier
        public async Task<ActionResult> Update(int id)
        {
            Supplier cat = await Repo.GetById(id);
            SupplierVM cVM = new SupplierVM
            {
                SupplierName = cat.SupplierName,
                SupplierID = cat.SupplierID
            };
            return View("_Update", cVM);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int SupplierID, SupplierVM vm)
        {
            Supplier c = new Supplier
            {
                SupplierName = vm.SupplierName,
                SupplierID = vm.SupplierID
            };
            int result = Repo.UpdateSupplier(SupplierID, c);
            if (result > 0)
            {
                ViewBag.result = "Error";
            }
            else
                ViewBag.result = "Error";
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}