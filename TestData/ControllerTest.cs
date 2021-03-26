using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using CodingExercise.Controllers;
using System.Web.Mvc;
using CodingExercise.DataAccess.Data;

namespace TestData
{
    [TestClass]
    public class ControllerTest
    {
        CarSalesEntities entities = new CarSalesEntities();
        [TestMethod]
        public void Index()
        {
            HomeController homeController = new HomeController();
            ViewResult result = homeController.Index() as ViewResult;
            Assert.IsNotNull(result); 
        }
    }
}
