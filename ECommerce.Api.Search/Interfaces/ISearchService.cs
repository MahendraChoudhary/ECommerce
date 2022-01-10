namespace ECommerce.Api.Search.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId);
    }
}
