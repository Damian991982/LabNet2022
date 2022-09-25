using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaEF.Entities;
using PracticaEF.Data;

namespace PracticaEF.Logic
{
    public class CategoriesLogic:BaseLogic,ILogic<Categories>
    {
        

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Create(Categories categories)
        {
            context.Categories.Add(categories);
            context.SaveChanges();
        }

        public Categories GetById(int id)
        {
            return context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
            // return context.Shippers.Find(id);
        }

        public void Edit(Categories categories)
        {
            var c = context.Categories.Find(categories.CategoryID);
            c.CategoryName = categories.CategoryName;
            c.Description = categories.Description;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = context.Categories.Find(id);
            context.Categories.Remove(c);
            context.SaveChanges();
        }
    }
}
