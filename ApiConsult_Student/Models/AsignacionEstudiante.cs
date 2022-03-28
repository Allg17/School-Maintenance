using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiConsult_Student.Models
{
    public class AsignacionEstudiante
    {
        public string NombreCompletoEstudiante { get; set; }
        public string NombreCompletoProfesor { get; set; }
        public string NombreAula { get; set; }
        public string NombreAsignatura { get; set; }
        public string Horario { get; set; }

        public static List<AsignacionEstudiante> Get(string param)
        {
            try
            {
                var res = param.Trim().Replace(" ", "|");
                var desc = res.Split('|');
                string Filtro = string.Empty;

                foreach (var item in desc)
                {
                    if (item.Trim().Length > 0)
                    {
                        Filtro += $" and (e.nombre like '%{item}%'  or e.apellido like '%{item}%')";
                    }
                }


                SqlConnection conStr = new SqlConnection(Conexion());
                return conStr.Query<AsignacionEstudiante>($"select e.Nombre + ' '+ e.Apellido NombreCompletoEstudiante,au.Curso NombreAula,asi.Nombre NombreAsignatura,asi.Horario,p.Nombre + ' '+ p.Apellido NombreCompletoProfesor " +
                    $" from estudiante e " +
                    $" inner join EstudiantesAgregados es on es.IDEstudiante = e.IDEstudiante" +
                    $" inner join AsignacionDeAulas a on a.AsignacionID = es.AsignacionID " +
                    $" inner join Aulas au on au.IDAula = a.IDAula " +
                    $" inner join AsignacionAulaDetalle ad on ad.AsignacionID = a.AsignacionID " +
                    $" inner join Asignatura asi on asi.IDAsignatura = ad.IDAsignatura " +
                    $" inner join Profesores p on p.IDProfesor = ad.IDProfesor" +
                    $" where 1=1 {Filtro}" +
                    $" order by NombreCompletoEstudiante,Horario,curso").ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static String Conexion()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            return conexion;
        }
    }
}