﻿namespace ECommerce.Api.Search.Services
{
    using ECommerce.Api.Search.Interfaces;
    using ECommerce.Api.Search.Models;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<ProductService> logger;

        public ProductService(IHttpClientFactory httpClientFactory, ILogger<ProductService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient("ProductsService");
                var response = await client.GetAsync($"api/products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, null, "");
            }
        }
    }
}
