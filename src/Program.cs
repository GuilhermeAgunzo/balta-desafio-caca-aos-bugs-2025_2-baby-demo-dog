using BugStore.Data;
using BugStore.Endpoints.Customers;
using BugStore.Endpoints.Products;
using BugStore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
{
  o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.AddServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGetCustomers();
app.MapGetCustomerById();
app.MapCreateCustomer();
app.MapUpdateCustomer();
app.MapDeleteCustomer();

app.MapGetProducts();
app.MapGetProductById();
app.MapPost("/v1/products", () => "Hello World!");
app.MapPut("/v1/products/{id}", () => "Hello World!");
app.MapDelete("/v1/products/{id}", () => "Hello World!");

app.MapGet("/v1/orders/{id}", () => "Hello World!");
app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
