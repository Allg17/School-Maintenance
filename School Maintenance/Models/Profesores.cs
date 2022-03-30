using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class Profesores
    {
        [Key]
        public int IDProfesor { get; set; }
        [Required(ErrorMessage = "Digite el Nombre del Profesor.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Digite el Apellido del Profesor.")]
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        [Range(18, 45, ErrorMessage = "Edad Permitida de 18 a 45")]
        public int Edad { get; set; }

        public virtual List<AsignacionAulaDetalle> Detalle { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get
            { return Nombre + " " + Apellido; }
        }
      
        public Profesores()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Sexo = "";
            Edad = 0;
        }
    }
}