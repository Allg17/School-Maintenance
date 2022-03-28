using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class Asignatura
    {
        [Key]
        public int IDAsignatura { get; set; }
        [Required(ErrorMessage = "Digite el Nombre de la Asignatura.")]
        public string Nombre { get; set; }
        public string Horario { get; set; }

        public virtual List<AsignacionAulaDetalle> Detalle { get; set; }
        [NotMapped]
        public string NombreCompleto
        {
            get { return Nombre + " " + Horario; }
        }

        public Asignatura()
        {
            Nombre = string.Empty;
            Horario = string.Empty;
        }
    }
}