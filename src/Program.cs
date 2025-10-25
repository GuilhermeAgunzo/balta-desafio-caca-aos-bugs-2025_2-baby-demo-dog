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
app.MapCreateProduct();
app.MapUpdateProduct();
app.MapDeleteProduct();

app.MapGet("/v1/orders/{id}", () => "Hello World!");
app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
