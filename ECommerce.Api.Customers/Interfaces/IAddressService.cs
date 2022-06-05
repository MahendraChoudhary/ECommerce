using ECommerce.Api.Customers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
    public interface IAddressService
    {
        Task CreateAddressAsync(Models.Address address);

        IEnumerable<Address> GetAddresses();
    }
}
