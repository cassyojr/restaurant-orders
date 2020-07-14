using Restaurant.Domain.Entity;
using Restaurant.Domain.Repository.Domain;
using Restaurant.Infra.Context;
using Restaurant.Infra.Repository.Standard;

namespace Restaurant.Infra.Repository.Domain
{
    public class OrderRepository : GenericRepositoryAsync<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
