namespace ECommerce.Api.Customers.Providers
{
    using AutoMapper;
    using ECommerce.Api.Customers.Db;
    using ECommerce.Api.Customers.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext customerDbContext;
        private readonly ILogger<CustomerService> logger;
        private readonly IMapper mapper;

        public CustomerService(CustomerDbContext customerDbContext, ILogger<CustomerService> logger, IMapper mapper)
        {
            this.customerDbContext = customerDbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if(!customerDbContext.Customers.Any())
            {
                customerDbContext.Customers.Add(new Customer() { Id = 1, Name = "Mahendra", Address = "Jaipur" });
                customerDbContext.Customers.Add(new Customer() { Id = 2, Name = "Ishika", Address = "Jaipur" });
                customerDbContext.Customers.Add(new Customer() { Id = 3, Name = "Jack", Address = "Bangalore" });
                customerDbContext.Customers.Add(new Customer() { Id = 4, Name = "Nancy", Address = "Mumbai" });
                customerDbContext.Customers.Add(new Customer() { Id = 5, Name = "John", Address = "Delhi" });

                customerDbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> 
            GetCustomerAsync(int id)
        {
            try
            {
                var customer = await customerDbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if (customer != null)
                {
                    var result = mapper.Map<Models.Customer>(customer);
                    return (true, result, "");
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> 
            GetCustomersAsync()
        {
            try
            {
                var customers = await customerDbContext.Customers.ToListAsync();
                if (customers != null)
                {
                    var result = mapper.Map<IEnumerable<Models.Customer>>(customers);
                    return (true, result, "");
                }

                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> 
            CreateCustomerAsync(Models.Customer customer)
        {
            try
            {
                var customerEntity = mapper.Map<Customer>(customer);
                await customerDbContext.Customers.AddAsync(customerEntity);
                await customerDbContext.SaveChangesAsync();
                return (true, "");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, ex.Message);
            }
        }
    }
}
