using School_Maintenance.DAL;
using School_Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace School_Maintenance.Repositorios
{
    public class EstudianteRepo : RepositorioBase<Estudiante>, IEstudiante
    {
        public SchoolContext Db { get; set; }
        public EstudianteRepo(ISchoolContext schoolContext) : base(schoolContext)
        {
            Db = schoolContext as SchoolContext;
        }

        public List<Estudiante> GetByParam(string param)
        {
            try
            {
                var losta = Db.EstudianteDb.Where(x => x.Nombre.Contains(param) || x.Apellido.Contains(param)).ToList();
                return losta;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}