using Autofac;
using Autofac.Integration.WebApi;
using Hive.Infrastructure.Contracts.Contracts;
using Hive.Infrastructure.Contracts.Mapper;
using Hive.Infrastructure.Implementations.Implementations;
using Hive.Mappers;
using Hive.ServiceLibrary.Contracts.Contracts;
using Hive.ServiceLibrary.Implementations.Implementations;
using System.Reflection;
using System.Web.Http;

namespace Hive.WebApi.App_Start
{
    internal static class RegisterDependencies
    {
        public static void Register(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Services
            builder.RegisterType<GetHiveService>().As<IGetHiveService>().InstancePerLifetimeScope();
            builder.RegisterType<AddBeeService>().As<IAddBeeService>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteBeeService>().As<IDeleteBeeService>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateBeeService>().As<IUpdateBeeService>().InstancePerLifetimeScope();

            // Repositories
            builder.RegisterType<BeeRepository>().As<IBeeRepository>().InstancePerLifetimeScope();

            // Mappers
            builder.RegisterType<InfrastructureMapper>().As<IInfrastructureMapper>().InstancePerLifetimeScope();
            builder.RegisterType<DomainMapper>().As<IDomainMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}