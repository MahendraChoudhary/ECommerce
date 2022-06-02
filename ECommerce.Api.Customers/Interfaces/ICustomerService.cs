namespace ECommerce.Api.Customers.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync();

        Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id);

        Task<(bool IsSuccess, string ErrorMessage)> CreateCustomerAsync(Models.Customer customer);
    }
}
