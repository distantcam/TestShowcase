using Autofac;
using WebApi.Infrastructure.Modules;

namespace WebApi.Tests.Infrastructure
{
    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MediatorModule>();
        }
    }
}
