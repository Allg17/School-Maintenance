using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static School_Maintenance.Models.Enums;

namespace School_Maintenance.ViewModel
{
    public class ProfesorViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Digite el Nombre del Profesor.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Digite el Apellido del Profesor.")]
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        [Range(18, 45, ErrorMessage = "Edad Permitida de 18 a 45")]
        public int Edad { get; set; }
        public List<string> Genero { get; set; }

        public ProfesorViewModel()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Sexo = "";
            Edad = 0;
            Genero = new List<string>(Enum.GetNames(typeof(GenderEnum)).ToList());
        }
    }
}