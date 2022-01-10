namespace ECommerce.Api.Orders.Controllers
{
    using ECommerce.Api.Orders.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderProvider orderProvider;

        public OrdersController(IOrderProvider orderProvider)
        {
            this.orderProvider = orderProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await orderProvider.GetOrdersAsync();
            if (result.IsSuccess)
                return Ok(result.Orders);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var result = await orderProvider.GetOrderAsync(id);
            if (result.IsSuccess)
                return Ok(result.Orders);

            return NotFound();
        }
    }
}
