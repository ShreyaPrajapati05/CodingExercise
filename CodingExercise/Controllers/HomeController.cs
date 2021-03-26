using CodingExercise.DataAccess.Data;
using CodingExercise.DataAccess.Services;
using CodingExercise.Models;
using System.Web.Mvc;

namespace CodingExercise.Controllers
{
    // Home controller
    public class HomeController : Controller
    {
        #region private variables
        private StateService stateService;
        private MonthService monthService;
        private RegionSaleService regionSaleService;
        #endregion

        #region public methods
        // constructor
        public HomeController()
        {
            stateService = new StateService();
            monthService = new MonthService();
            regionSaleService = new RegionSaleService();
        }

        // GET: Home
        public ActionResult Index()
        {
            RegionSaleModel model = new RegionSaleModel();

            model.StateList = stateService.get();
            model.MonthList = monthService.get();
            model.RegionSaleList = regionSaleService.getAll();

            return View(model);
        }

        // Post Save data in DB
        [HttpPost]
        public ActionResult Save(RegionSaleModel model)
        {
            if (ModelState.IsValid)
            {
                RegionSale regionSale = new RegionSale();

                regionSale.MonthId = model.MonthId;
                regionSale.StateId = model.StateId;
                regionSale.Sales = model.Sales;

                regionSaleService.save(regionSale);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}