using FluentAssertions;
using TestShared.Builders;
using WebApi.Features.Users;
using WebApi.Tests.Infrastructure;
using Xunit;

namespace WebApi.Tests.Features.Users;

public class GetUserTests : TestClassBase
{
    [Fact]
    public async Task SimpleGet()
    {
        // Arrange
        var user = UserBuilder.RandomFactory().Generate();
        TestDbContext.UserMock.Add(user);
        TestDbContext.UserMock.Add(UserBuilder.RandomFactory().GenerateForever().Take(10));

        // Act
        var response = await Mediator.Send(new GetUser.Query(user.Id));

        // Assert
        response.User.Should().BeEquivalentTo(user);
    }
}
