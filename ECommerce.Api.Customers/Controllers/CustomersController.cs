namespace ECommerce.Api.Customers.Controllers
{
    using ECommerce.Api.Customers.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProvider customerProvider;

        public CustomersController(ICustomerProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await customerProvider.GetCustomerAsync(id);
            if(result.IsSuccess)
            {
                return Ok(result.Customer);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await customerProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }

            return NotFound();
        }
    }
}
