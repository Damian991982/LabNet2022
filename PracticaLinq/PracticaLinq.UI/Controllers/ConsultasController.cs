using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaLinq.Entities;
using PracticaLinq.Logic;

namespace PracticaLinq.UI.Controllers
{
    public class ConsultasController : Controller
    {
        // GET: Consultas

        public ActionResult Consulta1()
        {
            //1. Query para devolver objeto customer


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta1());
        }
        public ActionResult ObtenerUnCustomer(string id)
        {
            //1. Query para devolver objeto customer

            try
            {
                
                Consultas objConsulta = new Consultas();

                return View(objConsulta.ObtenerUnCustomer(id));
            }
            catch (NullReferenceException nex)
            {
                ModelState.AddModelError("",nex.Message);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View();
            
        }

        public ActionResult Consulta2()
        {
            //2. Query para devolver todos los productos sin stock
            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta2());
        }

        public ActionResult Consulta3()
        {
            //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad

            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta3());
        }

        public ActionResult Consulta4()
        {
            //4.Query para devolver todos los customers de la Región WA

            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta4());
        }

        public ActionResult Consulta5()
        {
            //5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789

            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta5());
        }
        public ActionResult Consulta6()
        {
            //6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta6());
        }

        public ActionResult Consulta7()
        {
            //7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta7());
        }

        public ActionResult Consulta8()
        {
            //8. Query para devolver los primeros 3 Customers de la  Región WA


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta8());
        }
        public ActionResult Consulta9()
        {
            //9. Query para devolver lista de productos ordenados por nombre


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta9());
        }

        public ActionResult Consulta10()
        {
            //10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta10());
        }

        public ActionResult Consulta11()
        {
            //11. Query para devolver las distintas categorías asociadas a los productos


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta11());
        }

        public ActionResult Consulta12()
        {
            //12. Query para devolver el primer elemento de una lista de productos


            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta12());
        }

        public ActionResult Consulta13()
        {
            //13. Query para devolver los customer con la cantidad de ordenes asociadas

            Consultas objConsulta = new Consultas();

            return View(objConsulta.Consulta13());
        }

    }
}