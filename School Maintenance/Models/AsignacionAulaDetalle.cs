using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class AsignacionAulaDetalle
    {
        public int ID { get; set; }
        public int AsignacionID { get; set; }
        public virtual AsignacionDeAulas Asignacion { get; set; }
        public int IDAsignatura { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public int IDProfesor { get; set; }
        public virtual Profesores Profesor { get; set; }

    }
}