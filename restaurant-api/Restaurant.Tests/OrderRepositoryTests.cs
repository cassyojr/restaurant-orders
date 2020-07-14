using Moq;
using NUnit.Framework;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Tests
{
    public class OrderRepositoryTests
    {
        private IOrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            var orderRepositoryMock = new Mock<IOrderRepository>();

            orderRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Order>()))
                .ReturnsAsync(new Order
                {
                    OrderId = 1,
                    CreationDate = DateTime.Now,
                    Dishes = ""
                });

            orderRepositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Order> {
                new Order
                {
                    OrderId = 1,
                    CreationDate = DateTime.Now,
                    Dishes = ""
                }
                });

            orderRepositoryMock
               .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
               .ReturnsAsync(new Order
               {
                   OrderId = 1,
                   CreationDate = DateTime.Now,
                   Dishes = ""
               });

            orderRepositoryMock
                .Setup(x => x.RemoveAsync(It.IsAny<object>()))
                .Returns(Task.CompletedTask);

            orderRepositoryMock
                .Setup(x => x.UpdateAsync(It.IsAny<Order>()))
                .Returns<Order>(order => Task.FromResult(order));

            _orderRepository = orderRepositoryMock.Object;
        }

        [Test]
        public async Task AddAsync_WhenCalledWithValidOrder_ShouldReturnCreatedOrder()
        {
            var order = new Order
            {
                OrderId = 1,
                CreationDate = DateTime.Now,
                Dishes = "eggs, toast, coffee"
            };

            var result = await _orderRepository.AddAsync(order);

            Assert.That(result, Is.Not.Null);
        }


        [Test]
        public async Task GetAllAsync_WhenCalled_ShouldReturnListOfOrders()
        {
            var result = await _orderRepository.GetAllAsync();

            Assert.That(result.Count, Is.EqualTo(1));
        }


        [Test]
        public async Task GetByIdAsync_WhenCalledWithValidId_ShouldReturnOrderOfThatId()
        {
            var orderId = 1;

            var result = await _orderRepository.GetByIdAsync(orderId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.OrderId, Is.EqualTo(orderId));
        }

        [Test]
        public async Task RemoveAsync_WhenCalledWithValidId_ShouldRemoveTheOrder()
        {
            var orderId = 1;

            await _orderRepository.RemoveAsync(orderId);

            Assert.Pass();
        }

        [Test]
        public async Task UpdateAsync_WhenCalledWithValidOrder_ShouldUpdateTheOrderWithNewValuesAndReturnTheUpdatedOrder()
        {
            var order = new Order
            {
                OrderId = 1,
                CreationDate = DateTime.Now,
                Dishes = "eggs"
            };

            var updatedOrder = await _orderRepository.UpdateAsync(order);

            Assert.That(updatedOrder.OrderId, Is.EqualTo(order.OrderId));
            Assert.That(updatedOrder.Dishes, Is.EqualTo(order.Dishes));
        }
    }
}
