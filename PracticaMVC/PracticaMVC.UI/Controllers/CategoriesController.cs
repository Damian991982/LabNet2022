using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaMVC.Entities;
using PracticaMVC.Logic;
namespace PracticaMVC.UI.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {

            CategoriesLogic ObjCategories = new CategoriesLogic();


            return View(ObjCategories.GetAll());
        }



        [HttpGet]
        public ActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Categories());
            }
            else
            {
                CategoriesLogic objCategories = new CategoriesLogic();

                return View(objCategories.GetById(id));
            }

        }
        [HttpPost]
        public ActionResult CreateOrEdit(Categories categories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (categories.CategoryName == null)
                    {
                        ModelState.AddModelError("", "You must enter the name of the company");
                        return View(categories);
                    }
                    if (categories.CategoryID == 0)
                    {
                        CategoriesLogic objCategories = new CategoriesLogic();
                        objCategories.CreateOrEdit(categories);
                        return RedirectToAction("GetAll");

                    }
                    else
                    {
                        CategoriesLogic objCategories = new CategoriesLogic();
                        objCategories.CreateOrEdit(categories);
                        return RedirectToAction("GetAll");
                    }
                }
                else
                {

                    return View(categories);
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


            return View(categories);


        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            CategoriesLogic objCategories = new CategoriesLogic();
            var obj = objCategories.GetById(id.Value);


            return View(obj);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                CategoriesLogic objCategories = new CategoriesLogic();
                objCategories.Delete(id);
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