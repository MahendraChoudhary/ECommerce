namespace ECommerce.Api.Search.Interfaces
{
    using ECommerce.Api.Search.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsync(int customerId);
    }
}
