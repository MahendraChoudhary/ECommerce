namespace ECommerce.Api.Customers
{
    using AutoMapper;
    using ECommerce.Api.Customers.Db;
    using ECommerce.Api.Customers.Interfaces;
    using ECommerce.Api.Customers.Providers;
    using ECommerce.Helpers.Extensions;
    using ECommerce.Helpers.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using ECommerce.Api.Customers.Services;
    using ECommerce.Helpers.Configuration;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var identityServer = new IdentityServer();
            Configuration.GetSection("IdentityServer").Bind(identityServer);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = identityServer.Authority;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "customer";
                });

            services.AddHttpContextAccessor();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<UserService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseInMemoryDatabase("Customers");
            });
            services.AddControllers(options =>
            options.UseGeneralRoutePrefix("api/customer"));
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandler>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
