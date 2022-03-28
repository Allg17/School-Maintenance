using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static School_Maintenance.Models.Enums;

namespace School_Maintenance.ViewModel
{
    [NotMapped]
    public class EstudiantesViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Digite el Nombre del estudiante.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Digite el Apellido del estudiante.")]
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        [Range(5, 18, ErrorMessage = "Edad Permitida de 5 a 18")]
        public int Edad { get; set; }
        public List<string> Genero { get; set; }
        public EstudiantesViewModel()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Sexo = "";
            Edad = 0;
            Genero = new List<string>(Enum.GetNames(typeof(GenderEnum)).ToList());
        }
    }
}