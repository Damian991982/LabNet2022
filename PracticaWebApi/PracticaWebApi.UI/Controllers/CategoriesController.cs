using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using PracticaWebApi.Entities;
using PracticaWebApi.Service;
using System.Web.Http.Description;
using PracticaWebApi.UI.Models;

namespace PracticaWebApi.UI.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoriesService categoriesService;

        public CategoriesService CategoriesService
        {
            get
            {
                if (categoriesService == null)
                {
                    categoriesService = new CategoriesService();
                }
                return categoriesService;
            }
        }

        // GET: api/Categories

        public IHttpActionResult Get()
        {

            try
            {
                var listCategories = this.CategoriesService.Get();
                return Ok(listCategories);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Categories/1
        public IHttpActionResult Get(int id)
        {
            Categories objCategories = new Categories();
            try
            {
                objCategories = this.CategoriesService.Get(id);

                if (objCategories != null)
                {
                    CategoriesView categoriesView = new CategoriesView
                    {
                        CategoryID = objCategories.CategoryID,
                        CategoryName = objCategories.CategoryName,
                        Description = objCategories.Description,
                        Picture = objCategories.Picture, 
                    };
                    return Ok(objCategories);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"The categorie with the ID: '{id}' doesn't exist!.");
                }

            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        // POST: api/Categories
        [ResponseType(typeof(Categories))]
        public IHttpActionResult Post([FromBody] CategoriesView categoriesView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Categories ObjCategories = new Categories()
                    {
                        CategoryID = categoriesView.CategoryID,
                        CategoryName = categoriesView.CategoryName,
                        Description = categoriesView.Description,
                        Picture= categoriesView.Picture,
                    };

                    this.CategoriesService.Post(ObjCategories);
                    return Content(HttpStatusCode.Created, ObjCategories);

                }
                catch (Exception ex)
                {

                    return Content(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }

        }

        // PUT: api/Categories/5

        public IHttpActionResult Put([FromBody] CategoriesView categoriesView)
        {
            if (ModelState.IsValid)
            {
                if (CategoriesService.Get(categoriesView.CategoryID) != null)
                {
                    try
                    {
                        Categories ObjCategories = new Categories()
                        {
                            CategoryID = categoriesView.CategoryID,
                            CategoryName = categoriesView.CategoryName,
                            Description = categoriesView.Description,
                            Picture = categoriesView.Picture,

                        };
                        this.CategoriesService.Put(ObjCategories);
                        return Ok(ObjCategories);

                    }
                    catch (Exception ex)
                    {

                        return Content(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"The category with the ID: '{categoriesView.CategoryID}' doesn't exist!.");
                }

            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }

        }

        // DELETE: api/Shippers/1

        [ResponseType(typeof(Categories))]
        public IHttpActionResult Delete(int id)
        {

            try
            {
                if (CategoriesService.Get(id) != null)
                {
                    this.CategoriesService.Delete(id);
                    return Content(HttpStatusCode.Accepted, $"Categorie with the ID: {id} was deleted!.");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"The categorie with the ID: '{id}' doesn't exist!.");
                }


            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}