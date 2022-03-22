using Autofac;

namespace WebApi.Infrastructure.Modules;

public class AppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<MediatorModule>();
    }
}
