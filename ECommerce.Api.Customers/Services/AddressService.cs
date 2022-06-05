using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Services
{
    public class AddressService : IAddressService
    {
        private readonly CustomerDbContext customerDbContext;
        private readonly IMapper mapper;
        private readonly UserService userService;

        public AddressService(CustomerDbContext customerDbContext,
            IMapper mapper,
            UserService userService)
        {
            this.customerDbContext = customerDbContext;
            this.mapper = mapper;
            this.userService = userService;
        }

        public async Task CreateAddressAsync(Models.Address address)
        {
            var addressEntity = mapper.Map<Address>(address);
            addressEntity.CustomerId = userService.UserId;
            await customerDbContext.Addresses.AddAsync(addressEntity);
            await customerDbContext.SaveChangesAsync();
        }

        public IEnumerable<Models.Address> GetAddresses()
        {
            var addresses = customerDbContext.Addresses
                .Where(a => a.CustomerId == userService.UserId);

            return mapper.Map<IEnumerable<Models.Address>>(addresses);
        }
    }
}
