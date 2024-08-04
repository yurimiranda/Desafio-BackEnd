using MotorcycleRental.Application.Base;

namespace Autofac;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .RegisterAssemblyTypes(typeof(UseCaseBase).Assembly)
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}