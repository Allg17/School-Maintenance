using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class EstudiantesAgregados
    {
        [Key]
        public int IDEstudianteAgr { get; set; }
        public int AsignacionID { get; set; }
        public virtual AsignacionDeAulas Asignacion { get; set; }
        public int IDEstudiante { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}