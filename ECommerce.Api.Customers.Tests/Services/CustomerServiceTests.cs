using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace ECommerce.Api.Customers.Providers.Tests
{
    public class CustomerServiceTests
    {
        private CustomerService customerService;
        private CustomerDbContext dbContext;
        public CustomerServiceTests()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase("CustomersTest")
                .Options;
            dbContext = new CustomerDbContext(options);
            var customerProfile = new CustomerProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(customerProfile));
            var mapper = new Mapper(configuration);
            customerService = new CustomerService(dbContext, null, mapper);
        }


        [Fact]
        public async void GetCustomerAsyncWithExistingIdTest()
        {
            SeedCustomers();
            var result = await customerService.GetCustomerAsync(10);
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async void GetCustomersAsyncTest()
        {
            SeedCustomers();
            var result = await customerService.GetCustomersAsync();
            Assert.True(result.IsSuccess);
            Assert.True(result.Customers.Count() > 10);
        }

        [Fact]
        public async void CreateCustomerAsyncTest()
        {
            var result = await customerService.CreateCustomerAsync(
                new Models.Customer { Name = "Mahendra", Address = "India" });
            Assert.True(result.IsSuccess);
        }

        private void SeedCustomers()
        {
            for (int i = 0; i < 10; i++)
            {
                dbContext.Customers.Add(new Customer()
                {
                    Name = Guid.NewGuid().ToString(),
                    Address = Guid.NewGuid().ToString()
                });
            }

            dbContext.SaveChanges();
        }
    }
}