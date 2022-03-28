using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Maintenance.Models
{
    public class Aulas
    {
        [Key]
        public int IDAula { get; set; }
        [Required(ErrorMessage = "Digite el Nombre del Curso.")]
        public string Curso { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Por favor Ingrese una Capacidad mayor a 1.")]
        public int Capacidad { get; set; }
        public Aulas()
        {
            Curso = string.Empty;
            Capacidad = 1;
        }
    }
}