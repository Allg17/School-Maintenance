using School_Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Maintenance.Repositorios
{
    public interface IEstudiante: IBaseRepository<Estudiante>
    {
        List<Estudiante> GetByParam(string param);
    }
}
