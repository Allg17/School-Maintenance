using School_Maintenance.Models;
using School_Maintenance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Maintenance.Repositorios
{
    public interface IAsignacionDeAulas: IBaseRepository<AsignacionDeAulas>
    {
        Task<AsignarAulasViewModel> FillView();
        Task<List<AsignacionDeAulas>> Fill();
        List<AsignacionAulaDetalle> FillDetalle(int idprofesor);
        Task<AsignacionDeAulas> Fill(int id);
        Task<AsignarAulasViewModel> FillUpdate(int id);
        Task<bool> RefreshDataBase(List<Estudiante> estudiantes, int id);
        int UpdateAsignatura(AsignacionDeAulas asignatura);
    }
}
