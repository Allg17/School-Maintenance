using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static School_Maintenance.Models.Enumalert;

namespace School_Maintenance.Controllers
{
    public abstract class BaseController : Controller
    {

        public void Alert(string message, NotificationType notificationType, int opcion = 0)
        {
            string msg = "";
            switch (opcion)
            {
                case 0:
                    msg = "<script language='javascript'>Swal.fire('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
                    break;
                //case 1:
                //   // msg = "Swal.fire({ title: 'Seguro que desea Eliminar?', text: "klk", icon: 'warning', showCancelButton: true, confirmButtonColor: '#3085d6', cancelButtonColor: '#d33', confirmButtonText: 'Si!' }).then((result) => { if (result.isConfirmed) { Swal.fire( 'Deleted!', 'Registro Eliminado', 'success' ) } })";
                //    break;
                default:
                    break;
            }

            TempData["notification"] = msg;
        }
    }
}