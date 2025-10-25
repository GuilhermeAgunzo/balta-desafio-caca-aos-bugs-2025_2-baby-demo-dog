using BugStore.Abstractions.Handlers.Customers;
using BugStore.Data;
using BugStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Customers;

public class Handler(AppDbContext db) : IHandler
{
  public Task<Responses.Customers.Create> CreateCustomerAsync(Requests.Customers.Create request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public async Task<Responses.Customers.Delete> DeleteCustomerAsync(Requests.Customers.Delete request, CancellationToken cancellationToken)
  {
    try
    {
      var customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
      if (customer is null)
      {
        return new Responses.Customers.Delete(data: null, statusCode: 404, message: "Customer not found.");
      }
      db.Customers.Remove(customer);
      await db.SaveChangesAsync(cancellationToken);

      return new Responses.Customers.Delete(data: null, statusCode: 200, message: "Customer deleted successfully.");
    }
    catch
    {
      return new Responses.Customers.Delete(data: null, statusCode: 500, message: "An error occured while deleting the customer.");
    }
  }

  public async Task<Responses.Customers.GetById> GetCustomerByIdAsync(Requests.Customers.GetById request, CancellationToken cancellationToken)
  {
    try
    {
      var customer = await db.Customers
        .AsNoTracking()
        .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

      if (customer is null)
      {
        return new Responses.Customers.GetById(data: null, statusCode: 404, message: "Customer not found.");
      }

      return new Responses.Customers.GetById(data: customer);
    }
    catch
    {
      return new Responses.Customers.GetById(data: null, statusCode: 500, message: "An error occured while retrieving the customer.");
    }
  }

  public async Task<Responses.Customers.Get> GetCustomersAsync(Requests.Customers.Get request, CancellationToken cancellationToken)
  {
    try
    {
      var query = db.Customers
        .AsNoTracking()
        .Take(request.PageSize)
        .Skip((request.PageNumber - 1) * request.PageSize);

      var customers = await query.ToListAsync(cancellationToken);

      var total = await db.Customers.CountAsync(cancellationToken);

      return new Responses.Customers.Get(
        data: customers,
        totalCount: total,
        currentPage: request.PageNumber,
        pageSize: request.PageSize);

    }
    catch
    {
      return new Responses.Customers.Get(data: null, statusCode: 500, message: "An error occured while retrieving customers.");
    }
  }

  public Task<Responses.Customers.Update> UpdateCustomerAsync(Requests.Customers.Update request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}