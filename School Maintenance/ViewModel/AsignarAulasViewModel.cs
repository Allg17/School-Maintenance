using School_Maintenance.Models;
using School_Maintenance.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Maintenance.ViewModel
{
    public class AsignarAulasViewModel
    {
        [Key]
        public int AsignacionID { get; set; }
        public int IDAula { get; set; }
        public  Aulas Aula { get; set; }
        public  List<AsignacionAulaDetalle> Detalle { get; set; }
        public  List<Estudiante> Estudiante { get; set; }
        public  List<EstudiantesAgregados> EstudiantesAgregados { get; set; }
        public  List<Aulas> Aulas { get; set; }
        public  List<Profesores> Profesores { get; set; }
        public  List<Asignatura> Asignaturas { get; set; }

        public AsignarAulasViewModel()
        {
            Detalle = new List<AsignacionAulaDetalle>();
            Aula = new Aulas();
            Estudiante = new List<Estudiante>();
            Profesores = new List<Profesores>();
            Asignaturas = new List<Asignatura>();
            Aulas = new List<Aulas>();
            EstudiantesAgregados = new List<EstudiantesAgregados>();
        }

        public void FIll(IMasterRepository _MasterRepo)
        {
            Profesores = _MasterRepo.Profesores.GetAll().ToList();
            Asignaturas = _MasterRepo.Asignaturas.GetAll().ToList();
            Aulas = _MasterRepo.Aulas.GetAll().ToList();
        }
    }
}