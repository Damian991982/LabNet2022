using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaEF.Entities;
using PracticaEF.Logic;

namespace PracticaEF.UI.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CategoriesLogic ObjCategorie=new CategoriesLogic();

            return View(ObjCategorie.GetAll());

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            
            try
            {
               
                if (categories.CategoryName == null)
                {
                    ModelState.AddModelError("", "You must enter the name of the categorie");
                    return View(categories);
                }

                CategoriesLogic ObjCategories = new CategoriesLogic();
                ObjCategories.Create(categories);
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
            return View(categories);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CategoriesLogic objCategories = new CategoriesLogic();

            return View(objCategories.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Categories categories)
        {
            try
            {
                if (categories.CategoryName == null)
                {
                    ModelState.AddModelError("", "You must enter the name of the company");
                    return View(categories);

                }

                CategoriesLogic ObjCategories = new CategoriesLogic();
                ObjCategories.Edit(categories);
                return RedirectToAction("Index");
            }
            catch (FormatException fex)
            {
                ModelState.AddModelError("", fex.Message);
                return View(categories);
            }
            catch (ArgumentNullException aex)
            {
                ModelState.AddModelError("", aex.Message);
                return View(categories);
            }

            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(categories);
            }


        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {

            CategoriesLogic objCategories = new CategoriesLogic();
            var obj = objCategories.GetById(id.Value);


            return View(obj);
        }

        public ActionResult Delete(int id)
        {
            try
            {

                CategoriesLogic objCategories = new CategoriesLogic();
                objCategories.Delete(id);
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