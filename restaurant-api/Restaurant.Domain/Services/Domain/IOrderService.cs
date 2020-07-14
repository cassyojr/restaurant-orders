using Restaurant.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services.Domain
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> CreateOrderAsync(string dishes);
    }
}
