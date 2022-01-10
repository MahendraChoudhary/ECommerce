namespace Ecommerce.Api.Products.Tests
{
    using AutoMapper;
    using ECommerce.Api.Products.Db;
    using ECommerce.Api.Products.Profiles;
    using ECommerce.Api.Products.Providers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ProductsServiceTest
    {
        [Fact]
        public async Task GetProductsReturnsAllProducts()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts))
                .Options;
            var dbContext = new ProductsDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg=>cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductProvider(dbContext, null, mapper);

            var product = await productsProvider.GetProductsAsync();
            Assert.True(product.IsSuccess);
            Assert.True(product.Products.Any());
            Assert.True(string.IsNullOrEmpty(product.ErrorMessage));
        }

        [Fact]
        public async Task GetProductReturnProductUsingValidId()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(nameof(GetProductReturnProductUsingValidId))
                .Options;
            var dbContext = new ProductsDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductProvider(dbContext, null, mapper);

            var product = await productsProvider.GetProductAsync(1);
            Assert.True(product.IsSuccess);
            Assert.NotNull(product.Product);
            Assert.True(product.Product.Id==1);
            Assert.True(string.IsNullOrEmpty(product.ErrorMessage));
        }

        [Fact]
        public async Task GetProductReturnProductUsingInValidId()
        {
            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(nameof(GetProductReturnProductUsingInValidId))
                .Options;
            var dbContext = new ProductsDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductProvider(dbContext, null, mapper);

            var product = await productsProvider.GetProductAsync(-1);
            Assert.False(product.IsSuccess);
            Assert.Null(product.Product);
            Assert.False(string.IsNullOrEmpty(product.ErrorMessage));
        }

        private void CreateProducts(ProductsDbContext dbContext)
        {
            for (int i = 0; i < 10; i++)
            {
                dbContext.Products.Add(new Product() { Id = i + 1, Name = Guid.NewGuid().ToString(), Inventory = i + 10, Price = (decimal)(i * 3.14) });
            }

            dbContext.SaveChanges();
        }
    }
}
