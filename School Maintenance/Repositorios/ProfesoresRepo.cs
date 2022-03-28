using School_Maintenance.DAL;
using School_Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Maintenance.Repositorios
{
    public class ProfesoresRepo : RepositorioBase<Profesores>, IProfesores
    {
        public ProfesoresRepo(ISchoolContext schoolContext) : base(schoolContext)
        {

        }
    }
}