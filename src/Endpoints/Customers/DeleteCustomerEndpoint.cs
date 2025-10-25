using BugStore.Abstractions.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customers;

public static class DeleteCustomerEndpoint
{
  public static void MapDeleteCustomer(this WebApplication app)
  {
    app.MapDelete("/v1/customers/{id}", async Task<IResult> (
      [FromServices] IHandler customerHandler,
      Guid id,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Customers.Delete
      {
        Id = id
      };

      var result = await customerHandler.DeleteCustomerAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.NoContent()
        : TypedResults.NotFound();
    });
  }
}
