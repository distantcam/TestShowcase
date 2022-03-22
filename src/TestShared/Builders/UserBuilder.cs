using Bogus;
using Buildenator.Abstraction;
using Buildenator.Abstraction.Moq;
using WebApi.Data.Entities;

namespace TestShared.Builders;

[MakeBuilder(typeof(User))]
[MoqConfiguration]
public partial class UserBuilder
{
    public static UserBuilder Random()
    {
        var faker = new Faker();

        return new UserBuilder()
            .WithName(faker.Person.FullName)
            .WithEmail(faker.Person.Email);
    }

    public static Faker<User> RandomFactory()
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, _ => 0)
            .RuleFor(u => u.Name, f => f.Person.UserName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .StrictMode(true);
    }
}
