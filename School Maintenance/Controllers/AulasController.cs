using School_Maintenance.Models;
using School_Maintenance.Repositorios;
using School_Maintenance.Utils.Extensores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static School_Maintenance.Models.Enumalert;

namespace School_Maintenance.Controllers
{
    public class AulasController : BaseController
    {
        private readonly IMasterRepository _MasterRepo;
        public AulasController(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
        // GET: Aulas
        public ActionResult Index()
        {
            return View(_MasterRepo.Aulas.GetAll());
        }


        // GET: Aulas/Create
        public ActionResult Create()
        {
            return View(new Aulas());
        }

        // POST: Aulas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aulas collection)
        {
            try
            {
                if (_MasterRepo.Aulas.Save(collection) > 0)
                {
                    Alert("Curso Creado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al crear el Curso", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_MasterRepo.Aulas.GetById(id));
        }

        // POST: Aulas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aulas collection)
        {
            try
            {
                if (_MasterRepo.Aulas.Update(collection) > 0)
                {
                    Alert("Estudiante Actualizado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al Actualizar el estudiante", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_MasterRepo.Aulas.GetById(id));
        }

        // POST: Aulas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Aulas collection)
        {
            try
            {
                var res = _MasterRepo.Aulas.Delete(id);
                if (res > 0)
                {
                    Alert("Aula Eliminada Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al intentar eliminar el Aula", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
