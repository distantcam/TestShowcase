using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestShared;
using WebApi.Data;
using WebApi.Infrastructure.Modules;

namespace WebApi.Tests.Infrastructure;

public class ServicesFixture
{
    public IServiceProvider ServiceProvider { get; }

    public TestDbContext TestDbContext { get; private set; }

    public ServicesFixture()
    {
        TestDbContext = new TestDbContext();
        ServiceProvider = BuildServices();
    }

    public IServiceProvider BuildServices()
    {
        var services = new ServiceCollection();
        services.AddMediatR(typeof(MediatorModule).Assembly);

        var builder = new ContainerBuilder();
        builder.Populate(services);
        builder.RegisterInstance(TestDbContext).As<IAppDbContext>();
        builder.RegisterModule<TestModule>();

        var container = builder.Build();
        return new AutofacServiceProvider(container);
    }
}
