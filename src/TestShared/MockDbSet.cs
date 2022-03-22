using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using WebApi.Data.Entities;

namespace TestShared;

public class MockDbSet<T> where T : Entity
{
    private int _identity;

    public List<T> Data { get; }
    public Mock<DbSet<T>> DbSet { get; }

    public MockDbSet()
    {
        Data = new();
        DbSet = Data.AsQueryable().BuildMockDbSet();
    }

    public void Add(T item)
    {
        Data.Add(item);
        item.Id = _identity++;
    }

    public void Add(params T[] items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public void Add(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
}
