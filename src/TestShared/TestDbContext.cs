using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;

namespace TestShared;

public class TestDbContext : IAppDbContext
{
    public MockDbSet<User> UserMock { get; } = new();
    public DbSet<User> Users => UserMock.DbSet.Object;
}
