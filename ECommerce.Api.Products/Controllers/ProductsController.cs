namespace ECommerce.Api.Products.Controllers
{
    using ECommerce.Api.Products.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductProvider productProvider;

        public ProductsController(IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }

            return NotFound();
        }
    }
}
