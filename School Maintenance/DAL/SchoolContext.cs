using School_Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace School_Maintenance.DAL
{
    public interface ISchoolContext : IDisposable
    {

    }
    public class SchoolContext : DbContext, ISchoolContext
    {
        public SchoolContext() : base("ConStr")
        {

        }
        public DbSet<Estudiante> EstudianteDb { get; set; }
        public DbSet<Profesores> ProfesoresDb { get; set; }
        public DbSet<Aulas> AulasDb { get; set; }
        public DbSet<Asignatura> AsigntaturaDb { get; set; }
        public DbSet<AsignacionDeAulas> AsignacionDeAulasDb { get; set; }
        public DbSet<AsignacionAulaDetalle> AsignacionDetalleDb { get; set; }
        public DbSet<EstudiantesAgregados> EstudiantesAgregadosDb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<AsignacionDeAulas>().HasKey(x => x.AsignacionID).HasMany(x => x.Detalle);
            modelBuilder.Entity<AsignacionDeAulas>().HasMany(x => x.Estudiantes);
            //modelBuilder.Entity<AsignacionDeAulas>().HasRequired(x => x.Aula);
        }

    }
}