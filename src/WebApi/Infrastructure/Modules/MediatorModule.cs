using Autofac;
using MediatR;

namespace WebApi.Infrastructure.Modules;

public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register all the Command classes (they implement IRequestHandler)
        // in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(MediatorModule).GetType().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
    }
}
