using ECommerce.IdentityServer.Db;
using ECommerce.IdentityServer.Identity;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce.Helpers.Configuration;
using Serilog;

var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
//Initialize Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services
    .AddDbContext<IdentityDb>(options =>
    {
        PostgresSettings postgresSettings = new PostgresSettings();
        builder.Configuration.GetSection("Postgres").Bind(postgresSettings);
        Log.Information(postgresSettings.ToString());
        options.UseNpgsql($"Host={postgresSettings.Host};" +
            $"Port={postgresSettings.Port};Username={postgresSettings.Username};" +
            $"Password={postgresSettings.Password};Database={postgresSettings.Database};");
    })

    .AddIdentity<AppUser, IdentityRole>()
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
    .AddAspNetIdentity<AppUser>()
    .AddDeveloperSigningCredential()
    .AddResourceOwnerValidator<PasswordValidatorService>()
    .AddProfileService<UserProfileService>();

builder.Services
    .AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = scope.ServiceProvider.GetService<IdentityDb>();
    context.Database.Migrate();
}

string? port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(port))
{
    app.Urls.Add("http://*:" + port);
}

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
