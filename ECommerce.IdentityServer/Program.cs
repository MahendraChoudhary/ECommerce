using ECommerce.IdentityServer.Db;
using ECommerce.IdentityServer.Identity;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<IdentityDb>(options => options.UseInMemoryDatabase("Users"))
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDb>()
    .AddTokenProvider<TokenService>("TokenService");

builder.Services
    .AddIdentityServer(options =>
    {
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.Events.RaiseFailureEvents = true;
    })
    .AddInMemoryIdentityResources(Config.Ids)
    .AddInMemoryApiResources(Config.Apis)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddJwtBearerClientAuthentication()
    .AddAspNetIdentity<IdentityUser>()
    .AddDeveloperSigningCredential()
    .AddResourceOwnerValidator<PasswordValidatorService>();

builder.Services
    .AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Server V1");
    c.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseIdentityServer();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

SampleData.Initialize(app.Services);
app.Run();
