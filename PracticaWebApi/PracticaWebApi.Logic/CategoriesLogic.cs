using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaWebApi.Entities;

namespace PracticaWebApi.Logic
{
    public class CategoriesLogic:BaseLogic
    {
        public List<Categories> Get()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }

        }

        public Categories Get(int id)
        {
            try
            {
                return context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }

        }

        public void Post(Categories categories)
        {
            try
            {
                context.Categories.Add(categories);
                context.SaveChanges();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }
        }

        public void Put(Categories categories)
        {
            try
            {
                var c = context.Categories.Find(categories.CategoryID);
                c.CategoryName = categories.CategoryName;
                c.Description = categories.Description;
                c.Picture = categories.Picture;
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
                var c = context.Categories.Find(id);
                context.Categories.Remove(c);
                context.SaveChanges();
            }
            catch (InvalidOperationException ioe)
            {

                throw new Exception(ioe.Message);
            }

        }
    }
}
