using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Services.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Restaurant.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public RestaurantController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IList<Order>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid) return BadRequest("Invalid informations");

            var order = await _orderService.GetAllOrdersAsync();

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAsync([FromBody] string dishes)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid informations");

            var order = await _orderService.CreateOrderAsync(dishes);

            return Ok(order);
        }
    }
}
