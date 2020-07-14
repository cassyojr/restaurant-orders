using Restaurant.Domain.Entity;
using Restaurant.Domain.Repository.Standard;

namespace Restaurant.Domain.Repository.Domain
{
    public interface IOrderRepository : IGenericRepositoryAsync<Order>
    {
    }
}
