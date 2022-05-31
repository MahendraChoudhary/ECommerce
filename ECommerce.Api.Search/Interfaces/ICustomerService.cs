namespace ECommerce.Api.Search.Interfaces
{
    using ECommerce.Api.Search.Models;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsync(int customerId);
    }
}
