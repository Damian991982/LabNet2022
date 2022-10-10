using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaWebApi.Entities;
namespace PracticaWebApi.Service.Interfaces
{
    public interface ICategoriesService
    {
        List<Categories> Get();
        Categories Get(int id);

        void Post(Categories shippers);

        void Put(Categories shippers);

        void Delete(int id);
    }
}
