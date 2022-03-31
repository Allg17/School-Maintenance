using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class AsignacionDeAulas
    {
        [Key]
        public int AsignacionID { get; set; }
        public int IDAula { get; set; }
        public virtual Aulas Aula { get; set; }
        public virtual List<AsignacionAulaDetalle> Detalle { get; set; }
        public virtual List<EstudiantesAgregados> Estudiantes { get; set; }
        public AsignacionDeAulas()
        {
        }
    }
}