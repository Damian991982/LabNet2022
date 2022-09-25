using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaEF.Entities;
using PracticaEF.Logic;

namespace PracticaEF.UI.Controllers
{
    public class ShippersController : Controller
    {
        // GET: Shippers
        public ActionResult Index()
        {
            ShippersLogic ObjShippers = new ShippersLogic();

            return View(ObjShippers.GetAll());
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shippers shippers)
        {
            ViewBag.Shippers = shippers;
            try
            {
                if (shippers.CompanyName == null)
                {
                    ModelState.AddModelError("", "You must enter the name of the company");
                    return View(shippers);
                }

                ShippersLogic ObjShippers = new ShippersLogic();
                ObjShippers.Create(shippers);
                return RedirectToAction("Index");
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
        public ActionResult Edit(int id)
        {
            ShippersLogic objShippers = new ShippersLogic();

            return View(objShippers.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(Shippers shippers)
        {
            try
            {
                if (shippers.CompanyName == null)
                {
                    ModelState.AddModelError("", "You must enter the name of the company");
                    return View(shippers);

                }

                ShippersLogic ObjShippers = new ShippersLogic();
                ObjShippers.Edit(shippers);
                return RedirectToAction("Index");
            }
            catch (FormatException fex)
            {
                ModelState.AddModelError("", fex.Message);
                return View(shippers);
            }
            catch (ArgumentNullException aex)
            {
                ModelState.AddModelError("", aex.Message);
                return View(shippers);
            }

            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(shippers);
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {

            ShippersLogic objShippers = new ShippersLogic();
            var obj = objShippers.GetById(id.Value);


            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            try
            {

                ShippersLogic objShippers = new ShippersLogic();
                objShippers.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();

            }
        }
    }
}