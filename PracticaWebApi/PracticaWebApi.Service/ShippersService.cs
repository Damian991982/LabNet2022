using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaWebApi.Entities;
using PracticaWebApi.Service.Interfaces;
using PracticaWebApi.Logic;

namespace PracticaWebApi.Service
{
    public class ShippersService : IShippersService
    {
        private ShippersLogic logic;

        public ShippersLogic ShippersLogic
        {
            get
            {
                if (logic == null)
                {
                    logic = new ShippersLogic();
                }
                return logic;
            }
        }
        public void Delete(int id)
        {

            try
            {
                this.ShippersLogic.Delete(id);
            }
            catch (Exception)
            {

                throw new Exception("No se pudo realizar la accion");
            }
        }

        public List<Shippers> Get()
        {
            try
            {
                return this.ShippersLogic.Get();
            }
            catch (Exception)
            {

                throw new Exception("No se pudo realizar la accion");
            }
        }

        public Shippers Get(int id)
        {
            try
            {
                return (this.ShippersLogic.Get(id));
            }
            catch (Exception)
            {

                throw new Exception("No se pudo realizar la accion");
            }
        }

        public void Post(Shippers shippers)
        {
            try
            {
                this.ShippersLogic.Post(shippers);
            }
            catch (Exception)
            {

                throw new Exception("No se pudo realizar la accion");
            }
        }

        public void Put(Shippers shippers)
        {
            try
            {
                this.ShippersLogic.Put(shippers);
            }
            catch (Exception)
            {

                throw new Exception("No se pudo realizar la accion");
            }
        }

    }
}
