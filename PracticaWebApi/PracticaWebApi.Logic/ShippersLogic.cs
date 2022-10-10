using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaWebApi.Entities;


namespace PracticaWebApi.Logic
{
    public class ShippersLogic:BaseLogic
    {
        public List<Shippers> Get()
        {
            try
            {
                return context.Shippers.ToList();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }
            
        }
        public Shippers Get(int id)
        {
            try
            {
                return context.Shippers.Where(x => x.ShipperID == id).FirstOrDefault();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }
           
            
        }

        public void Post(Shippers shippers)
        {
            try
            {
                context.Shippers.Add(shippers);
                context.SaveChanges();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }
        }

        public void Put(Shippers shippers)
        {
            try
            {
                var s = context.Shippers.Find(shippers.ShipperID);
                s.CompanyName = shippers.CompanyName;
                s.Phone = shippers.Phone;
                context.SaveChanges();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }
           
        }

        public void Delete(int id)
        {
            try
            {
                var s = context.Shippers.Find(id);
                context.Shippers.Remove(s);
                context.SaveChanges();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }
           
        }

    }
}
