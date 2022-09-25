using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaEF.Entities;

namespace PracticaEF.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();
        void Create(T entity);
        void Edit(T entity);
        T GetById(int id);
        void Delete(int id);
    }
}
