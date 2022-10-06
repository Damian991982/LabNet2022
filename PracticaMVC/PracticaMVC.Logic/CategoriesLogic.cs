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
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public void Create(Categories entity)
        {

            context.Categories.Add(entity);
            context.SaveChanges();
        }

        public void CreateOrEdit(Categories entity)
        {
            if (entity.CategoryID == 0)
            {
                context.Categories.Add(entity);
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
            var s = context.Categories.Find(id);
            context.Categories.Remove(s);
            context.SaveChanges();
        }

        public void Edit(Categories entity)
        {
            var c = context.Categories.Find(entity.CategoryID);
            c.CategoryName = entity.CategoryName;
            c.Description = entity.Description;
            c.Picture = entity.Picture;
            context.SaveChanges();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            return context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
        }
    }
}
