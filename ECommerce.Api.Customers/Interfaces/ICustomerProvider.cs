namespace ECommerce.Api.Customers.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync();

        Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
