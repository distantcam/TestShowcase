using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestShared;

namespace WebApi.Tests.Infrastructure
{
    public class TestClassBase
    {
        public ServicesFixture Fixture { get; set; }

        public IMediator Mediator => Fixture.ServiceProvider.GetService<IMediator>();

        public TestDbContext TestDbContext => Fixture.TestDbContext;

        public TestClassBase()
        {
            Fixture = new ServicesFixture();
        }
    }
}
