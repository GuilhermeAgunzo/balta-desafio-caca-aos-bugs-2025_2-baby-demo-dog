using BugStore.Abstractions.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customers;

public static class UpdateCustomerEndpoint
{
  public static void MapUpdateCustomer(this WebApplication app)
  {
    app.MapPut("/v1/customers/{id}", async Task<IResult> (
      [FromServices] IHandler customerHandler,
      Guid id,
      Requests.Customers.Update request,
      CancellationToken cancellationToken = default) =>
    {
      request.Id = id;
      var result = await customerHandler.UpdateCustomerAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.BadRequest();
    });
  }
}
