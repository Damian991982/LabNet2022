using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaWebApi.Entities;


namespace PracticaWebApi.Service.Interfaces
{
    public interface IShippersService
    {
        List<Shippers> Get();
        Shippers Get(int id);

        void Post(Shippers shippers);

        void Put(Shippers shippers);

        void Delete(int id);
    }
}
