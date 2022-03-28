using School_Maintenance.Utils.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class Estudiante
    {
        [Key]
        public int IDEstudiante { get; set; }
        [Required(ErrorMessage = "Digite el Nombre del estudiante.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Digite el Apellido del estudiante.")]
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        [Range(5, 18, ErrorMessage = "Edad Permitida de 5 a 18")]
        public int Edad { get; set; }

        [NotMapped]
        public bool EstudianteSeleccionado { get; set; }

        //public int AsignacionID { get; set; }
        //public virtual AsignacionDeAulas Asignacion { get; set; }


        public Estudiante()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Sexo = "";
            Edad = 0;
        }
    }
}