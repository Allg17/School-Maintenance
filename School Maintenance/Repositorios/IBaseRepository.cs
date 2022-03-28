using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Maintenance.Repositorios
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Save(T obj);
        int Delete(int Id);
        int Update(T obj);
    }
}
