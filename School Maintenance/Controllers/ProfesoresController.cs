using School_Maintenance.Models;
using School_Maintenance.Repositorios;
using School_Maintenance.Utils.Extensores;
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
    public class ProfesoresController : BaseController
    {
        private readonly IMasterRepository _MasterRepo;
        public ProfesoresController(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
        // GET: Profesores
        public ActionResult Index()
        {
            return View(_MasterRepo.Profesores.GetAll());
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View(new ProfesorViewModel());
        }

        // POST: Profesores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfesorViewModel collection)
        {
            try
            {
                if (_MasterRepo.Profesores.Save(new Profesores
                {
                    Nombre = collection.Nombre,
                    Apellido = collection.Apellido,
                    Edad = collection.Edad,
                    Sexo = collection.Sexo
                }) > 0)
                {
                    Alert("Profesor Creado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al crear el Profesor", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int id)
        {
            var res = _MasterRepo.Profesores.GetById(id);
            return View(new ProfesorViewModel
            {
                Nombre = res.Nombre,
                Apellido = res.Apellido,
                Edad = res.Edad,
                Sexo = res.Sexo,
                Genero = new List<string>(Enum.GetNames(typeof(GenderEnum)).ToList())
            });
        }

        // POST: Profesores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProfesorViewModel collection)
        {
            try
            {
                if (_MasterRepo.Profesores.Update(new Profesores
                {
                    Nombre = collection.Nombre,
                    Apellido = collection.Apellido,
                    Edad = collection.Edad,
                    Sexo = collection.Sexo,
                    IDProfesor = id
                }) > 0)
                {
                    Alert("Profesor Actualizado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al Actualizar el Profesor", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_MasterRepo.Profesores.GetById(id));
        }

        // POST: Profesores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Profesores collection)
        {
            try
            {
                var res = _MasterRepo.Profesores.Delete(id);
                if (res > 0)
                {
                    Alert("Profesor Eliminado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al intentar eliminar el Profesor", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
