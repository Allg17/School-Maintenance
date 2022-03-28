using School_Maintenance.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Unity;

namespace School_Maintenance.Repositorios
{
    public class RepositorioBase<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        [Dependency]
        public SchoolContext Db { get; set; }
        public RepositorioBase(ISchoolContext schoolContext)
        {
            Database.SetInitializer<SchoolContext>(null);
            Db = schoolContext as SchoolContext;
        }
        public int Delete(int Id)
        {
            Db.Set<TEntity>().Remove(GetById(Id));
            return Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public int Save(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            return Db.SaveChanges();
        }

        public int Update(TEntity obj)
        {
           
            Db.Entry(obj).State = EntityState.Modified;
            return Db.SaveChanges();
        }
        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

       
    }
}