using Order.Application.Repository;
using Order.Domain.SeedWork;

namespace Order.Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    public Task<int> SaveChangesAsync()
    {
        return Task.FromResult(1);
    }
}