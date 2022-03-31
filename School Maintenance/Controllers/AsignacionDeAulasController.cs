using School_Maintenance.Models;
using School_Maintenance.Repositorios;
using School_Maintenance.Utils.Extensores;
using School_Maintenance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static School_Maintenance.Models.Enumalert;

namespace School_Maintenance.Controllers
{
    public class AsignacionDeAulasController : BaseController
    {
        private readonly IMasterRepository _MasterRepo;
        public AsignacionDeAulasController(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
        // GET: AsignacionDeAulas
        public async Task<ActionResult> Index()
        {
            return View(await _MasterRepo.AsignacionDeAulas.Fill());
        }

        // GET: AsignacionDeAulas/Create
        public async Task<ActionResult> Create()
        {
            var res = await _MasterRepo.AsignacionDeAulas.FillView();

            bool paso = true;
            if (res.Profesores.Count == 0)
            {
                Alert("Debe de Agregar Profesores antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }
            else if (res.Estudiante.Count == 0)
            {
                Alert("Debe de Estudiantes Profesores antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }
            else if (res.Asignaturas.Count == 0)
            {
                Alert("Debe de Agregar Asignaturas antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }
            else if (res.Aulas.Count == 0)
            {
                Alert("Debe de Agregar aulas antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }

            if (paso)
            {
                return View(res);
            }
            else
                return View("Index");
        }

        // POST: AsignacionDeAulas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsignarAulasViewModel asignarAulasViewModel)
        {
            try
            {
                var tuple = Validate(asignarAulasViewModel);
                if (!tuple.Item1)
                {
                    return View(tuple.Item2);
                }

                List<EstudiantesAgregados> detalle = new List<EstudiantesAgregados>();
                foreach (var item in asignarAulasViewModel.Estudiante.Where(x => x.EstudianteSeleccionado))
                {
                    detalle.Add(new EstudiantesAgregados
                    {
                        IDEstudiante = item.IDEstudiante,
                    });
                }

                if (_MasterRepo.AsignacionDeAulas.Save(new AsignacionDeAulas
                {
                    Detalle = asignarAulasViewModel.Detalle,
                    Estudiantes = detalle,
                    IDAula = asignarAulasViewModel.IDAula
                }) > 0)
                {
                    Alert("Asignacion Creada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                {
                    asignarAulasViewModel.FIll(_MasterRepo);
                    tuple.Item2.FIll(_MasterRepo);
                    return View(tuple.Item2);
                }

            }
            catch
            {
                asignarAulasViewModel.FIll(_MasterRepo);
                return View(asignarAulasViewModel);
            }
        }

        // GET: AsignacionDeAulas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var res = await _MasterRepo.AsignacionDeAulas.FillUpdate(id);
            bool paso = true;
            if (res.Profesores.Count == 0)
            {
                Alert("Debe de Agregar Profesores antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }
            else if (res.Estudiante.Count == 0)
            {
                Alert("Debe de Estudiantes Profesores antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }
            else if (res.Asignaturas.Count == 0)
            {
                Alert("Debe de Agregar Asignaturas antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }
            else if (res.Aulas.Count == 0)
            {
                Alert("Debe de Agregar aulas antes de continuar a la asignacion", NotificationType.error);
                paso = false;
            }

            if (paso)
            {
                return View(res);
            }
            else
                return View("Index");
        }

        // POST: AsignacionDeAulas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AsignarAulasViewModel asignarAulasViewModel)
        {
            try
            {
                var tuple = Validate(asignarAulasViewModel);
                if (!tuple.Item1)
                {
                    return View(tuple.Item2);
                }

                IEnumerable<EstudiantesAgregados> detalle = from p in asignarAulasViewModel.Estudiante
                                                            where p.EstudianteSeleccionado
                                                            select new EstudiantesAgregados
                                                            {
                                                                IDEstudiante =
                                                                 p.IDEstudiante,
                                                                AsignacionID = id
                                                            };


                if (_MasterRepo.AsignacionDeAulas.UpdateAsignatura(new AsignacionDeAulas
                {
                    Detalle = asignarAulasViewModel.Detalle,
                    Estudiantes = detalle.ToList(),
                    IDAula = asignarAulasViewModel.IDAula,
                    AsignacionID = id
                }) > 0)
                {
                    Alert("Asignacion Actualizada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                {
                    tuple.Item2.FIll(_MasterRepo);
                    return View(tuple.Item2);
                }
            }
            catch (Exception ex)
            {
                asignarAulasViewModel.FIll(_MasterRepo);
                return View(asignarAulasViewModel);
            }
        }

        // GET: AsignacionDeAulas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _MasterRepo.AsignacionDeAulas.Fill(id));
        }

        // POST: AsignacionDeAulas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AsignacionDeAulas collection)
        {
            try
            {
                var res = _MasterRepo.AsignacionDeAulas.Delete(id);
                if (res > 0)
                {
                    Alert("Asignacion Eliminada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al intentar eliminar la Asignacion", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        private Tuple<bool, AsignarAulasViewModel> Validate(AsignarAulasViewModel asignarAulasViewModel)
        {
            if (asignarAulasViewModel.Estudiante.Where(x => x.EstudianteSeleccionado).Count() == 0)
            {
                Alert("Debe seleccionar estudiantes antes de finalizar.", NotificationType.error);
                asignarAulasViewModel.FIll(_MasterRepo);
                return new Tuple<bool, AsignarAulasViewModel>(false, asignarAulasViewModel);
            }

            var asignaturas = _MasterRepo.Asignaturas.GetAll();
            var query =
                         from p in asignaturas
                         join o in asignarAulasViewModel.Detalle on p.IDAsignatura equals o.IDAsignatura
                         select p;

            foreach (var item in asignarAulasViewModel.Detalle)
            {
                var detalles = _MasterRepo.AsignacionDeAulas.FillDetalle(item.IDProfesor);
                var query1 =
                         from p in asignaturas
                         join o in detalles on p.IDAsignatura equals o.IDAsignatura
                         where o.AsignacionID != asignarAulasViewModel.AsignacionID
                         select p;

                var r = query1.ToList();
                var asig = _MasterRepo.Asignaturas.GetById(item.IDAsignatura);
                if (query1.ToList().Where(x => x.Horario == asig.Horario).Count() > 0)
                {
                    Alert("Tiene profesores con el mismo horario en otras aulas.", NotificationType.error);
                    asignarAulasViewModel.FIll(_MasterRepo);
                    return new Tuple<bool, AsignarAulasViewModel>(false, asignarAulasViewModel);
                }
            }
            var rq = query.ToList();
            if (query.ToList().GroupBy(t => t).Where(t => t.Count() != 1).Count() > 0 || query.ToList().GroupBy(t => t.Horario).Where(t => t.Count() != 1).Count() > 0)
            {
                Alert("No puede tener materias con el mismo horario o materias duplicadas.", NotificationType.error);
                asignarAulasViewModel.FIll(_MasterRepo);
                return new Tuple<bool, AsignarAulasViewModel>(false, asignarAulasViewModel);
            }

            if (_MasterRepo.Aulas.GetById(asignarAulasViewModel.IDAula).Capacidad < asignarAulasViewModel.Estudiante.Where(x => x.EstudianteSeleccionado).Count())
            {
                Alert("No puede sobre pasar la capacidad del curso, capacida del curso = " + asignarAulasViewModel.Aula.Capacidad, NotificationType.error);
                asignarAulasViewModel.FIll(_MasterRepo);
                return new Tuple<bool, AsignarAulasViewModel>(false, asignarAulasViewModel);
            }

            return new Tuple<bool, AsignarAulasViewModel>(true, asignarAulasViewModel);
        }
    }
}
