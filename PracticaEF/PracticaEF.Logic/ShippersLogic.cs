using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaEF.Entities;
using PracticaEF.Data;

namespace PracticaEF.Logic
{
    public class ShippersLogic:BaseLogic,ILogic<Shippers>
    {
        

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public void Create(Shippers shippers)
        {
            context.Shippers.Add(shippers);
            context.SaveChanges();
        }

        public Shippers GetById(int id)
        {
            return context.Shippers.Where(s => s.ShipperID==id).FirstOrDefault();
           // return context.Shippers.Find(id);
        }

        public void Edit(Shippers shippers)
        {
            var s = context.Shippers.Find(shippers.ShipperID);
            s.CompanyName = shippers.CompanyName;
            s.Phone = shippers.Phone;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = context.Shippers.Find(id);
            context.Shippers.Remove(s);
            context.SaveChanges();
        }

    }
}
