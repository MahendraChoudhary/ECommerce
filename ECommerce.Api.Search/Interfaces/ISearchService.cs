namespace ECommerce.Api.Search.Interfaces
{
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId);
    }
}
