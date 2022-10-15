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
using System.Web.Http.Cors;


namespace PracticaWebApi.UI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ShippersController : ApiController
    {
        private ShippersService shippersService;

        public ShippersService ShippersService
        {
            get
            {
                if (shippersService == null)
                {
                    shippersService = new ShippersService();
                }
                return shippersService;
            }
        }


        // GET: api/Shippers

        public IHttpActionResult Get()
        {

            try
            {
                var listShippers = this.ShippersService.Get();
                return Ok(listShippers);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/Shippers/1
        public IHttpActionResult Get(int id)
        {
            Shippers objShipper = new Shippers();
            try
            {
                objShipper = this.ShippersService.Get(id);

                if(objShipper != null)
                {
                    ShippersView shippersView = new ShippersView
                    {
                        ShipperID = objShipper.ShipperID,
                        CompanyName = objShipper.CompanyName,
                        Phone=objShipper.Phone,
                    };
                    return Ok(objShipper);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, $"The shipper with the ID: '{id}' doesn't exist!.");
                }
                
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        // POST: api/Shippers
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult Post([FromBody] ShippersView shippersView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Shippers ObjShippers = new Shippers()
                    {
                        ShipperID = shippersView.ShipperID,
                        CompanyName = shippersView.CompanyName,
                        Phone = shippersView.Phone,
                    };

                    this.ShippersService.Post(ObjShippers);
                    return Content(HttpStatusCode.Created, ObjShippers);

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

        // PUT: api/Shippers/5

        public IHttpActionResult Put([FromBody] ShippersView shippersView)
        {
            if (ModelState.IsValid)
            {
                if(ShippersService.Get(shippersView.ShipperID) != null)
                {
                    try
                    {
                        Shippers ObjShippers = new Shippers()
                        {
                            ShipperID = shippersView.ShipperID,
                            CompanyName = shippersView.CompanyName,
                            Phone = shippersView.Phone,

                        };
                        this.ShippersService.Put(ObjShippers);
                        return Ok(ObjShippers);

                    }
                    catch (Exception ex)
                    {

                        return Content(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,$"The category with the ID: '{shippersView.ShipperID}' doesn't exist!.");
                }

            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Fields are missing or too long!.");
            }
            
        }

        // DELETE: api/Shippers/1

        [ResponseType(typeof(Shippers))]
        public IHttpActionResult Delete(int id)
        {
            
            try
            {
                if(ShippersService.Get(id) != null)
                {
                    this.ShippersService.Delete(id);
                    return Content(HttpStatusCode.Accepted, $"Shipper with the ID: {id} was deleted!.");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound,$"The shipper with the ID: '{id}' doesn't exist!.");
                }
                
                
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}