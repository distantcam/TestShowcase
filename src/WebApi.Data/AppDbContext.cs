using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
}

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
