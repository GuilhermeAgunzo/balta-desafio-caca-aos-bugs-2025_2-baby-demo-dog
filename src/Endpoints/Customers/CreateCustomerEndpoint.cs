using System;
using BugStore.Abstractions.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customers;

public static class CreateCustomerEndpoint
{
  public static void MapCreateCustomer(this WebApplication app)
  {
    app.MapPost("/v1/customers", async Task<IResult> (
      [FromServices] IHandler customerHandler,
      Requests.Customers.Create request,
      CancellationToken cancellationToken = default) =>
    {
      var result = await customerHandler.CreateCustomerAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Created($"/v1/customers/{result.Data?.Id}", result)
        : TypedResults.BadRequest();
    });
  }

}
