using Restaurant.Domain.Entity;
using Restaurant.Domain.Repository.Domain;
using Restaurant.Domain.Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Application.Services.Domain
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(string dishes)
        {
            if (string.IsNullOrEmpty(dishes)) throw new ArgumentNullException("Dishes cannot be null");

            var order = new Order
            {
                CreationDate = DateTime.Now,
                Dishes = dishes
            };
            return await _orderRepository.AddAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.OrderByDescending(x => x.CreationDate).ToList();
        }
    }
}
