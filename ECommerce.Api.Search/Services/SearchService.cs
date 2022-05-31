namespace ECommerce.Api.Search.Services
{
    using ECommerce.Api.Search.Interfaces;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public SearchService(IOrderService orderService, IProductService productService, ICustomerService customerService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;
        }

        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var orderResult = await orderService.GetOrdersAsync(customerId);
            var customerResult = await customerService.GetCustomerAsync(customerId);
            var productsResult = await productService.GetProductsAsync();
            if (orderResult.IsSuccess)
            {
                foreach (var order in orderResult.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productsResult.IsSuccess ?
                            productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId)?.Name
                            : "Product info not available";
                    }
                }

                var result = new
                {
                    Customer = customerResult.IsSuccess ? customerResult.Customer?.Name : "Customer info not available",
                    Orders = orderResult.Orders
                };

                return (true, result);
            }

            return (false, orderResult.ErrorMessage);
        }
    }
}
