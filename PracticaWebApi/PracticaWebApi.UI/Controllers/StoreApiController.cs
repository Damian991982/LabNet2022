using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PracticaWebApi.Entities;
using PracticaWebApi.Entities.DTOs;
using PracticaWebApi.Logic;
using PracticaWebApi.UI.Models;

namespace PracticaWebApi.UI.Controllers
{
    public class StoreApiController : Controller
    {
        StoreApiLogic storeLogic=new StoreApiLogic();
        // GET: StoreApi
        public async Task<ActionResult> Index()
        {
            List<StoreApiDto> products = await storeLogic.GetProducts();

            List<StoreApiView> productView = products.Select(p => new StoreApiView
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Category = p.Category,
                Description = p.Description,
                Image = p.Image,
            }).ToList();

            return View(productView);
        }
    }
}