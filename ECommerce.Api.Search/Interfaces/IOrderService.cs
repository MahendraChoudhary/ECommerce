namespace ECommerce.Api.Search.Interfaces
{
    using ECommerce.Api.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task<(bool IsSuccess, IEnumerable<Order> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
