using School_Maintenance.DAL;
using School_Maintenance.Models;
using School_Maintenance.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace School_Maintenance.Repositorios
{
    public class AsignacionDeAulasRepo : RepositorioBase<AsignacionDeAulas>, IAsignacionDeAulas
    {
        public SchoolContext Db { get; set; }
        public AsignacionDeAulasRepo(ISchoolContext schoolContext) : base(schoolContext)
        {
            Db = schoolContext as SchoolContext;
        }

        public async Task<AsignarAulasViewModel> FillView()
        {
            try
            {
                var aulas = await Db.AulasDb.AsNoTracking().ToListAsync();
                var profesores = await Db.ProfesoresDb.AsNoTracking().ToListAsync();
                var estudiantes = await Db.EstudianteDb.AsNoTracking().ToListAsync();
                var asignaturas = await Db.AsigntaturaDb.AsNoTracking().ToListAsync();


                var model = new AsignarAulasViewModel()
                {
                    Profesores = profesores,
                    Estudiante = estudiantes,
                    Aulas = aulas,
                    Asignaturas = asignaturas,
                    Detalle = new List<AsignacionAulaDetalle> { new AsignacionAulaDetalle { IDAsignatura = 1, IDProfesor = 1 } }
                };

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AsignacionDeAulas>> Fill()
        {
            try
            {
                var aulas = await Db.AsignacionDeAulasDb.Include(x => x.Detalle).Include(x => x.Aula).Include(x => x.Estudiantes).AsNoTracking().ToListAsync();
                return aulas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AsignacionDeAulas> Fill(int id)
        {
            try
            {
                var aulas = await Db.AsignacionDeAulasDb.Include(x => x.Detalle).Include(x => x.Aula).Include(x => x.Estudiantes).AsNoTracking().FirstOrDefaultAsync(x => x.AsignacionID == id);
                return aulas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AsignarAulasViewModel> FillUpdate(int id)
        {
            try
            {
                var aulas = await Db.AulasDb.AsNoTracking().ToListAsync();
                var profesores = await Db.ProfesoresDb.AsNoTracking().ToListAsync();
                var estudiantes = await Db.EstudianteDb.AsNoTracking().ToListAsync();
                var asignaturas = await Db.AsigntaturaDb.AsNoTracking().ToListAsync();

                var aula = await Db.AsignacionDeAulasDb.Include(x => x.Detalle).AsNoTracking().Include(x => x.Aula).AsNoTracking().Include(x => x.Estudiantes).AsNoTracking().
                FirstOrDefaultAsync(x => x.AsignacionID == id);

                foreach (var item in aula.Estudiantes)
                {
                    if (estudiantes.Where(x => x.IDEstudiante == item.IDEstudiante).Count() > 0)
                    {
                        estudiantes.Where(x => x.IDEstudiante == item.IDEstudiante).First().EstudianteSeleccionado = true;
                    }
                }

                var model = new AsignarAulasViewModel()
                {
                    Profesores = profesores,
                    Estudiante = estudiantes,
                    Aulas = aulas,
                    Asignaturas = asignaturas,
                    Detalle = aula.Detalle,
                    Aula = aula.Aula,
                    IDAula = aula.IDAula,
                    AsignacionID = aula.AsignacionID,
                    EstudiantesAgregados = aula.Estudiantes
                };


                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> RefreshDataBase(List<Estudiante> estudiantes, int id)
        {
            try
            {
                var aula = await Db.AsignacionDeAulasDb.Include(x => x.Estudiantes).AsNoTracking().
                FirstOrDefaultAsync(x => x.AsignacionID == id);

                foreach (var item in aula.Estudiantes)
                {
                    if (estudiantes.Where(x => x.IDEstudiante == item.IDEstudiante).Count() == 0)
                    {
                        Db.EstudiantesAgregadosDb.Remove(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<AsignacionAulaDetalle> FillDetalle(int idprofesor)
        {
            try
            {
                var aulas = Db.AsignacionDetalleDb.Where(x => x.IDProfesor == idprofesor).ToList();
                return aulas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateAsignatura(AsignacionDeAulas asignatura)
        {
            try
            {
                foreach (var item in asignatura.Detalle)
                {
                    if (item.ID > 0)
                    {
                        Db.AsignacionDetalleDb.Remove(Db.AsignacionDetalleDb.Find(item.ID));
                        item.ID = 0;
                    }
                    Db.AsignacionDetalleDb.Add(item);
                }

                var aula = Db.AsignacionDeAulasDb.Include(x => x.Estudiantes).AsNoTracking().
               FirstOrDefault(x => x.AsignacionID == asignatura.AsignacionID);

                foreach (var item in aula.Estudiantes)
                {
                    if (asignatura.Estudiantes.Where(x => x.IDEstudiante == item.IDEstudiante).Count() == 0)
                    {
                        Db.EstudiantesAgregadosDb.Remove(Db.EstudiantesAgregadosDb.Find(item.IDEstudianteAgr));
                    }
                    else
                    {
                        asignatura.Estudiantes.RemoveAll(x => x.IDEstudiante == item.IDEstudiante);
                    }
                }

                foreach (var item in asignatura.Estudiantes)
                {
                    if (item.IDEstudianteAgr == 0)
                        Db.EstudiantesAgregadosDb.Add(item);
                }
                return Db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}