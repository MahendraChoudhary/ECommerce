﻿namespace ECommerce.Api.Search.Controllers
{
    using ECommerce.Api.Search.Interfaces;
    using ECommerce.Api.Search.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm searchTerm)
        {
            var result = await searchService.SearchAsync(searchTerm.CustomerId);
            if(result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }

            return NotFound();
        }
    }
}
