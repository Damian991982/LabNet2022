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
    public class CategoriesService : ICategoriesService
    {
        private CategoriesLogic logic;

        public CategoriesLogic CategoriesLogic
        {
            get
            {
                if (logic == null)
                {
                    logic = new CategoriesLogic();
                }
                return logic;
            }
        }
        public void Delete(int id)
        {
            try
            {
                this.CategoriesLogic.Delete(id);
            }
            catch (Exception)
            {

                throw new Exception("The action could not be performed");
            }
        }

        public List<Categories> Get()
        {
            try
            {
                return this.CategoriesLogic.Get();
            }
            catch (Exception)
            {

                throw new Exception("The action could not be performed");
            }
        }

        public Categories Get(int id)
        {
            try
            {
                return this.CategoriesLogic.Get(id);
            }
            catch (Exception)
            {

                throw new Exception("The action could not be performed");
            }
        }

        public void Post(Categories categories)
        {
            try
            {
                this.CategoriesLogic.Post(categories);
            }
            catch (Exception)
            {

                throw new Exception("The action could not be performed");
            }
        }

        public void Put(Categories categories)
        {
            try
            {
                this.CategoriesLogic.Put(categories);
            }
            catch (Exception)
            {

                throw new Exception("The action could not be performed");
            }
        }
    }
}
