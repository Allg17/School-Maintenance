using School_Maintenance.Models;
using School_Maintenance.Repositorios;
using School_Maintenance.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static School_Maintenance.Models.Enumalert;
using static School_Maintenance.Models.Enums;

namespace School_Maintenance.Controllers
{
    public class AsignaturaController : BaseController
    {
        private readonly IMasterRepository _MasterRepo;
        public AsignaturaController(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
        // GET: Asignatura
        public ActionResult Index()
        {
            return View(_MasterRepo.Asignaturas.GetAll());
        }


        // GET: Asignatura/Create
        public ActionResult Create()
        {
            return View(new AsignaturaViewModel());
        }

        // POST: Asignatura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsignaturaViewModel collection)
        {
            try
            {
                if (_MasterRepo.Asignaturas.Save(new Asignatura
                {
                    Nombre = collection.Nombre,
                    Horario = collection.Horario
                }) > 0)
                {
                    Alert("Asignatura Creada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al crear la asignatura", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Asignatura/Edit/5
        public ActionResult Edit(int id)
        {
            var res = _MasterRepo.Asignaturas.GetById(id);
            return View(new AsignaturaViewModel
            {
                Nombre = res.Nombre,
                Horario = res.Horario,
                Horarios = new List<string>(Enum.GetNames(typeof(HorarioEnum)).ToList()),
                ID = id
            });
        }

        // POST: Asignatura/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AsignaturaViewModel collection)
        {
            try
            {
                if (_MasterRepo.Asignaturas.Update(new Asignatura
                {
                    Nombre = collection.Nombre,
                    Horario = collection.Horario,
                    IDAsignatura = id
                }) > 0)
                {
                    Alert("Asignatura Actualizada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al Actualizar la asignatura", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Asignatura/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_MasterRepo.Asignaturas.GetById(id));
        }

        // POST: Asignatura/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Asignatura collection)
        {
            try
            {
                if (_MasterRepo.Asignaturas.Delete(id) > 0)
                {
                    Alert("Asignatura Eliminada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al intentar eliminar la Asignatura", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
