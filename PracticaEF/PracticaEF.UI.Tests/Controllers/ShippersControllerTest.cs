using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaEF.UI;
using PracticaEF.UI.Controllers;
using PracticaEF.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace PracticaEF.UI.Tests.Controllers
{
    [TestClass]
    public class ShippersControllerTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IndexTest()
        {
            // Arrange
            ShippersController controller = new ShippersController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            

            // Assert
            Assert.IsNull("Index",result.ViewName);
            


        }
        [TestMethod]
        
        public void ViewTest()
        {
            ShippersController controller = new ShippersController();

            Shippers ObjShipper = new Shippers();

            
            ViewResult result = controller.Create() as ViewResult;

            Assert.IsInstanceOfType(result.ViewBag, typeof(Shippers));


        }

       
    }
}
