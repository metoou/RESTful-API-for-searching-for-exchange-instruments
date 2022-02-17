using Autofac;
using TestTask.Abstractions;

namespace TestTask.Core
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>().InstancePerLifetimeScope();
        }
    }
}
