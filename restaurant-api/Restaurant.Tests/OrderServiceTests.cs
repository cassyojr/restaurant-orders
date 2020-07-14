using Moq;
using NUnit.Framework;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Services.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Tests
{
    public class OrderServiceTests
    {
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            var orderServiceMock = new Mock<IOrderService>();
          
            orderServiceMock
                .Setup(x => x.GetAllOrdersAsync())
                .ReturnsAsync(new List<Order> {
                   new Order
                    {
                        OrderId = 1,
                        CreationDate = DateTime.Now,
                        Dishes = ""
                    }
                });

            orderServiceMock
                .Setup(x => x.CreateOrderAsync(It.IsAny<string>()))
                .Returns<string>(x => Task.FromResult(new Order
                {
                    OrderId = 2,
                    CreationDate = DateTime.Now,
                    Dishes = x
                }));

            _orderService = orderServiceMock.Object;
        }

        [Test]
        public async Task GetAllOrdersAsync_WhenCalled_ShouldReturnListOfOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase("eggs, toast, coffee")]
        [TestCase("eggs, toast, coffee(x3)")]
        public async Task CreateOrderAsync_WhenCalledWithValidDishes_ShouldReturnCreatedOrderWithSameDishes(string dishes)
        {
            var result = await _orderService.CreateOrderAsync(dishes);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Dishes, Is.EqualTo(dishes));
        }
    }
}