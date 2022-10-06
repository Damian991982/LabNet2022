using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaMVC.Entities;
using PracticaMVC.Data;
using System.Data.Entity;
namespace PracticaMVC.Logic
{
    public class ShippersLogic:BaseLogic,ILogic<Shippers>
    {
        public void Create(Shippers entity)
        {
            context.Shippers.Add(entity);
            context.SaveChanges();
        }

        public void CreateOrEdit(Shippers entity)
        {
            if (entity.ShipperID == 0)
            {
                context.Shippers.Add(entity);
                context.SaveChanges();
            }
            else
            {
                //var s = context.Shippers.Find(entity.ShipperID);
                //s.CompanyName = entity.CompanyName;
                //s.Phone = entity.Phone;
                //context.SaveChanges();
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

            }

        }

        public void Delete(int id)
        {
            var s = context.Shippers.Find(id);
            context.Shippers.Remove(s);
            context.SaveChanges();
        }

        public void Edit(Shippers entity)
        {
            var s = context.Shippers.Find(entity.ShipperID);
            s.CompanyName = entity.CompanyName;
            s.Phone = entity.Phone;
            context.SaveChanges();
        }

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public Shippers GetById(int id)
        {
            return context.Shippers.Where(s => s.ShipperID == id).FirstOrDefault();
        }
    }
}
