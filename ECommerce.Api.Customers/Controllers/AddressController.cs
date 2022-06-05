using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("address")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IEnumerable<Address> GetAddresses()
        {
            return _addressService.GetAddresses();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Address address)
        {
            await _addressService.CreateAddressAsync(address);
            return Ok();
        }
    }
}
