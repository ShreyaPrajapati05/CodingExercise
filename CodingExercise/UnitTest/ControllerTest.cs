using CodingExercise.Controllers;
using CodingExercise.DataAccess.Services;
using CodingExercise.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;

namespace CodingExercise
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController homeController = new HomeController();
            ViewResult result = homeController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Save()
        {
            HomeController homeController = new HomeController();
            RegionSaleModel regionSaleModel = new RegionSaleModel();
            regionSaleModel.MonthId = 1;
            regionSaleModel.StateId = 1;
            regionSaleModel.Sales = 121;
            homeController.Save(regionSaleModel);
            var viewResult = homeController.Index() as ViewResult;
            var viewRegionSaleModel = viewResult.Model as RegionSaleModel;
            var temp = viewRegionSaleModel.RegionSaleList.AsEnumerable().Where(rs => rs.StateId == 1 && rs.MonthId == 1).FirstOrDefault().Sales == 121;
            Assert.IsTrue(temp);
        }
        [TestMethod]
        public void CheckTotalSales()
        {
            HomeController homeController = new HomeController();
            RegionSaleModel regionSaleModel = new RegionSaleModel();
            RegionSaleService regionSaleService = new RegionSaleService();
            regionSaleModel.MonthId = 1;
            regionSaleModel.StateId = 1;
            regionSaleModel.Sales = 100;
            homeController.Save(regionSaleModel);
            regionSaleModel.MonthId = 2;
            regionSaleModel.StateId = 2;
            regionSaleModel.Sales = 200;
            homeController.Save(regionSaleModel);
            var viewResult = homeController.Index() as ViewResult;
            Assert.AreEqual(100, regionSaleService.getById(1, 1).Sales);
            Assert.AreEqual(200, regionSaleService.getById(2, 2).Sales);
            
        }
    }
}