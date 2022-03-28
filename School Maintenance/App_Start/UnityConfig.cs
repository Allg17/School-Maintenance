using School_Maintenance.DAL;
using School_Maintenance.Repositorios;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace School_Maintenance
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMasterRepository, MasterRepository>();
            container.RegisterType<ISchoolContext, SchoolContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}