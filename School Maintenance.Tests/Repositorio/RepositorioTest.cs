using Microsoft.VisualStudio.TestTools.UnitTesting;
using School_Maintenance.DAL;
using School_Maintenance.Models;
using School_Maintenance.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School_Maintenance.Tests.Repositorio
{
    /// <summary>
    /// Summary description for RepositorioTest
    /// </summary>
    [TestClass]
    public class RepositorioTest
    {

        [TestMethod]
        public void Save()
        {
            ISchoolContext context = new SchoolContext();
            RepositorioBase<Estudiante> rp = new Repositorios.RepositorioBase<Estudiante>(context);
            var res = rp.Save(new Estudiante
            {
                Nombre = "test",
                Apellido = "Test Test",
                Edad = 12,
                Sexo = "Fem"
            });
            Assert.IsTrue(res > 0);
        }

        [TestMethod]
        public void Delete()
        {
            ISchoolContext context = new SchoolContext();
            RepositorioBase<Estudiante> rp = new Repositorios.RepositorioBase<Estudiante>(context);
            var res = rp.Delete(1004);
            Assert.IsTrue(res > 0);
        }

        [TestMethod]
        public void Update()
        {
            ISchoolContext context = new SchoolContext();
            RepositorioBase<Estudiante> rp = new Repositorios.RepositorioBase<Estudiante>(context);
            var res = rp.Update(new Estudiante
            {
                Nombre = "Tester",
                Apellido = "Test Test",
                Edad = 13,
                Sexo = "",
                IDEstudiante = 1003
            });
            Assert.IsTrue(res > 0);
        }

        [TestMethod]
        public void Getall()
        {
            ISchoolContext context = new SchoolContext();
            RepositorioBase<Estudiante> rp = new Repositorios.RepositorioBase<Estudiante>(context);
            var res = rp.GetAll();
            Assert.IsTrue(res.ToList().Count() > 0);
        }

        [TestMethod]
        public void GetById()
        {
            ISchoolContext context = new SchoolContext();
            RepositorioBase<Estudiante> rp = new Repositorios.RepositorioBase<Estudiante>(context);
            var res = rp.GetById(1002);
            Assert.IsTrue(res.IDEstudiante > 0);
        }
    }
}
