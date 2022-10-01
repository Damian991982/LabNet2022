using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaLinq.Entities;
using PruebaLinq.Entities.Dto;

namespace PracticaLinq.Logic
{
    public class Consultas:BaseLogic
    {
        public List<Customers> Consulta1()
        {
            //1. Query para devolver objeto customer, esta consulta genera una lista de Customers,
            //De la cual se podra seleccionar cualquiera de ellos para visualizar su detalle,
            //con la consulta GetOneCustomer

            


            var con1 = context.Customers.ToList();


            return con1;
        }

        public Customers ObtenerUnCustomer(string id)
        {
            //1. Query para devolver objeto customer, esta consulta obtendra el detalle de un Customer que se podra seleccionar de una vista de lista.
            var conGetOne = context.Customers.Where(c => c.CustomerID == id).SingleOrDefault();
            return (conGetOne != null) ? conGetOne : throw new NullReferenceException(); ;
        }

        public List<Products> Consulta2()
        {
            //2.Query para devolver todos los productos sin stock



            var con2 = context.Products.Where(ut => ut.UnitsInStock == 0);


            return con2.ToList();
        }

        public List<Products> Consulta3()
        {
            //3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad


            var con3 = context.Products.Where(x => x.UnitsInStock > 0 && x.UnitPrice > 3).ToList();


            return con3;
        }

        public List<Customers> Consulta4()
        {
            //4. Query para devolver todos los customers de la Región WA

            var con4 = context.Customers.Where(x => x.Region == "WA").ToList();

            return con4;
        }

        public Products Consulta5()
        {
            //5.Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789

            var con5 = context.Products.Where(x => x.ProductID == 789).FirstOrDefault();

            return con5;
        }

        public List<Customers> Consulta6()
        {
            //6.Query para devolver los nombre de los Customers.Mostrarlos en Mayuscula y en Minuscula.(No lo logre)


            List<Customers> lstCustomer = new List<Customers>();
            lstCustomer = context.Customers.ToList();

            lstCustomer.ForEach(x =>
            {
                x.CompanyName = x.CompanyName.ToUpper();
                x.CompanyName = x.CompanyName.ToLower();
            });

            var con6 = lstCustomer.ToList();

            return con6;

        }

        public IEnumerable<CustomersOrdersDto> Consulta7()
        {
            //7. Query para devolver Join entre Customers y Orders donde los customers sean de la 
            //Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.

            DateTime date = new DateTime(1997, 01, 01);

            var con7 = from customer in context.Customers
                       join orders in context.Orders
                       on customer.CustomerID equals orders.CustomerID
                       where orders.OrderDate > date && customer.Region == "WA"
                       select new CustomersOrdersDto
                       {
                           CustomerID = customer.CustomerID,
                           CompanyName = customer.CompanyName,
                           OrderID = orders.OrderID,
                           Region = customer.Region,
                           OrderDate = orders.OrderDate,
                       };

            return con7;



        }

        public List<Customers> Consulta8()
        {
            //8. Query para devolver los primeros 3 Customers de la  Región WA
            var con8 = context.Customers.Where(x => x.Region == "WA").Take(3).ToList();
            return con8;
        }

        public List<Products> Consulta9()
        {
            //9.Query para devolver lista de productos ordenados por nombre
            var con9 = context.Products.OrderBy(x => x.ProductName).ToList();

            return con9;

        }

        public List<Products> Consulta10()
        {
            //10.Query para devolver lista de productos ordenados por unit in stock de mayor a menor.

            var con10 = from products in context.Products
                        where products.UnitsInStock > 0
                        orderby products.UnitsInStock descending
                        select products;

            return con10.ToList();
        }

        public IEnumerable<ProductsCategoriesDto> Consulta11()
        {
            //11. Query para devolver las distintas categorías asociadas a los productos
            var con11 = from categories in context.Categories
                        join products in context.Products
                        on categories.CategoryID equals products.CategoryID
                        orderby categories.CategoryID ascending
                        select new ProductsCategoriesDto
                        {
                            CategoryID = categories.CategoryID,
                            CategoryName = categories.CategoryName,
                            ProductName = products.ProductName,
                        };


            return con11.ToList();
        }

        public Products Consulta12()
        {
            //12. Query para devolver el primer elemento de una lista de productos
            var cons12 = context.Products.FirstOrDefault();
            return cons12;
        }

        public IEnumerable<CustomersOrdersDto> Consulta13()
        {
            //13. Query para devolver los customer con la cantidad de ordenes asociadas


            var con13 = from customer in context.Customers
                        join order in context.Orders
                        on customer.CustomerID equals order.CustomerID
                        group customer by new
                        {
                            customer.CustomerID,
                            customer.CompanyName,

                        }
                        into tempTable

                        select new CustomersOrdersDto
                        {
                            CustomerID = tempTable.Key.CustomerID,
                            CompanyName = tempTable.Key.CompanyName,
                            QuantityOrders = tempTable.Count(),
                        };

            return con13;

        }





    }
}
