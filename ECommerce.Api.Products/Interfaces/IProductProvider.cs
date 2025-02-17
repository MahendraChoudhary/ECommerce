﻿namespace ECommerce.Api.Products.Interfaces
{
    using ECommerce.Api.Products.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductProvider
    {
        Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();

        Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id);
    }
}
