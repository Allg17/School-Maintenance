using School_Maintenance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Maintenance.Repositorios
{
    public class MasterRepository : IMasterRepository
    {
        public IEstudiante Estudiante { get; set; }
        public IProfesores Profesores { get; set; }
        public IAulas Aulas { get; set; }
        public IAsignaturas Asignaturas { get; set; }
        public IAsignacionDeAulas AsignacionDeAulas { get ; set ; }

        public MasterRepository(ISchoolContext schoolContext)
        {
            Estudiante = new EstudianteRepo(schoolContext);
            Profesores = new ProfesoresRepo(schoolContext);
            Aulas = new AulasRepo(schoolContext);
            Asignaturas = new AsignaturaRepo(schoolContext);
            AsignacionDeAulas = new AsignacionDeAulasRepo(schoolContext);
        }
    }
}