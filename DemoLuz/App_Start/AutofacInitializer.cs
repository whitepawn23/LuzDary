using Autofac;
using Autofac.Integration.Mvc;
using DemoLuz.Code.Environment;
using DemoLuz.Core.Configuration;
using DemoLuz.Core.Environment;
using DemoLuz.DataAccess;
using DemoLuz.DataAccess.Core;
using DemoLuz.DataAccess.Core.EF;
using DemoLuz.DataAccess.Core.EF.Base;
using DemoLuz.Services.Companies;
using DemoLuz.Services.Employees;
using System.Reflection;
using System.Web.Mvc;

namespace DemoLuz.App_Start
{

    public class AutofacInitializer
    {
        private static IContainer _container;
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            //Infraestructure
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LuzDbContext>().As<BaseContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationConfigurator>().As<IConfigurator>();
            builder.RegisterType<ApplicationEnvironment>().As<IApplicationEnvironment>();
            //Services
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();

            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            return _container;
        }

    }
}