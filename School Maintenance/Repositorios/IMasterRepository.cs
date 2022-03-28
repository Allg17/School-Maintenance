using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Maintenance.Repositorios
{
    public interface IMasterRepository
    {
        IEstudiante Estudiante { get; set; }
        IProfesores Profesores { get; set; }
        IAulas Aulas { get; set; }
        IAsignaturas Asignaturas { get; set; }
        IAsignacionDeAulas AsignacionDeAulas { get; set; }
    }
}
