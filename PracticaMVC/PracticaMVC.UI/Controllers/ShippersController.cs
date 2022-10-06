using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaMVC.Entities;
using PracticaMVC.Logic;

namespace PracticaMVC.UI.Controllers
{
    public class ShippersController : Controller
    {
        // GET: Shippers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {

            ShippersLogic ObjShippers = new ShippersLogic();


            return View(ObjShippers.GetAll());
        }


       
        [HttpGet]
        public ActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Shippers());
            }
            else
            {
                ShippersLogic objShippers = new ShippersLogic();

                return View(objShippers.GetById(id));
            }

        }
        [HttpPost]
        public ActionResult CreateOrEdit(Shippers shippers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (shippers.CompanyName == null)
                    {
                        ModelState.AddModelError("", "You must enter the name of the company");
                        return View(shippers);
                    }
                    if (shippers.ShipperID == 0)
                    {
                        ShippersLogic objShippers = new ShippersLogic();
                        objShippers.CreateOrEdit(shippers);
                        return RedirectToAction("GetAll");

                    }
                    else
                    {
                        ShippersLogic objShippers = new ShippersLogic();
                        objShippers.CreateOrEdit(shippers);
                        return RedirectToAction("GetAll");
                    }
                }
                else
                {

                    return View(shippers);
                }
            }
            catch (FormatException fex)
            {

                ModelState.AddModelError("", fex.Message);
            }
            catch (ArgumentNullException aex)
            {
                ModelState.AddModelError("", aex.Message);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);

            }


            return View(shippers);


        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ShippersLogic objShippers = new ShippersLogic();
            var obj = objShippers.GetById(id.Value);


            return View(obj);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                ShippersLogic objShippers = new ShippersLogic();
                objShippers.Delete(id);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();

            }
        }
    }
}