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
using static School_Maintenance.Models.Enums ;

namespace School_Maintenance.Controllers
{
    public class EstudiantesController : BaseController
    {
        private readonly IMasterRepository _iMasterRepo;
        public EstudiantesController(IMasterRepository masterRepository)
        {
            _iMasterRepo = masterRepository;
        }
        // GET: Estudiantes
        public ActionResult Index()
        {

            return View(_iMasterRepo.Estudiante.GetAll());
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {

            return View(new EstudiantesViewModel());
        }

        // POST: Estudiantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstudiantesViewModel collection)
        {
            try
            {

                if (_iMasterRepo.Estudiante.Save(new Estudiante
                {
                    Nombre = collection.Nombre,
                    Apellido = collection.Apellido,
                    Edad = collection.Edad,
                    Sexo = collection.Sexo
                }) > 0)
                {
                    Alert("Estudiante Creado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al crear el estudiante", NotificationType.error);

                return View(collection);

            }
            catch (Exception ex)
            {
                return View(collection);
            }
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int id)
        {
            var res = _iMasterRepo.Estudiante.GetById(id);
            return View(new EstudiantesViewModel
            {
                Nombre = res.Nombre,
                Apellido = res.Apellido,
                Edad = res.Edad,
                Sexo = res.Sexo,
                Genero = new List<string>(Enum.GetNames(typeof(GenderEnum)).ToList()),
                ID = id
            });
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstudiantesViewModel collection)
        {
            try
            {
                if (_iMasterRepo.Estudiante.Update(new Estudiante
                {
                    Nombre = collection.Nombre,
                    Apellido = collection.Apellido,
                    Edad = collection.Edad,
                    Sexo = collection.Sexo,
                    IDEstudiante = id
                }) > 0)
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

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_iMasterRepo.Estudiante.GetById(id));
        }

        // POST: Estudiantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Estudiante collection)
        {
            try
            {
                var res = _iMasterRepo.Estudiante.Delete(id);
                if (res > 0)
                {
                    Alert("Estudiante Eliminado Exitosamente", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                    Alert("Ocurrio un error al intentar eliminar el estudiante", NotificationType.error);

                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
