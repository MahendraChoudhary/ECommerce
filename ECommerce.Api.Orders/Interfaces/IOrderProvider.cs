namespace ECommerce.Api.Orders.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrderProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsync();

        Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrderAsync(int customerId);
    }
}
