
using Bemol.Customer.Api.Controllers.ViewModels;
using Bemol.Customer.Api.Data.Context;
using Bemol.Customer.Api.Data.Repositories;
using Bemol.Customer.Api.Data.Repositories.Interfaces;
using Bemol.Customer.Api.Domain.Models;
using Bemol.Customer.Api.Domain.Services;
using Bemol.Customer.Api.Domain.Services.Interfaces;
using Bemol.Customer.Api.Integrations.External.ViaCep;
using Bemol.Customer.Api.Integrations.External.ViaCep.Interfaces;
using Microsoft.EntityFrameworkCore;
using RestSharp;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<AddCustomer, Customer>();
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IViaCepService, ViaCepService>();
builder.Services.AddSingleton<RestClient>(new RestClient(new RestClientOptions()));

builder.Services.AddControllers();

var postgresConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseNpgsql(postgresConnection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CustomerContext>();
    dbContext.Database.Migrate();
}

app.Run();
