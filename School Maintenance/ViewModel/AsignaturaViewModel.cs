using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static School_Maintenance.Models.Enums;

namespace School_Maintenance.ViewModel
{
    public class AsignaturaViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Digite el Nombre de la Asignatura.")]
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public List<string> Horarios { get; set; }
        public AsignaturaViewModel()
        {
            Nombre = string.Empty;
            Horario = string.Empty;
            Horarios = new List<string>(Enum.GetNames(typeof(HorarioEnum)).ToList());
        }
    }
}