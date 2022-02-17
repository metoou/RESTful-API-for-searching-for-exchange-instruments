using Autofac;
using TestTask.Abstractions;
using Module = Autofac.Module;

namespace TestTask.Sql
{
    public class SqlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}
