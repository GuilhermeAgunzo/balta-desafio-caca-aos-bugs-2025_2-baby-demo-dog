using System;
using BugStore.Abstractions.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customers;

public static class GetCustomersEndpoint
{
  public static void MapGetCustomers(this IEndpointRouteBuilder routes)
  {
    routes.MapGet("/v1/customers", async Task<IResult> (
      [FromServices] IHandler customerHandler,
      int page = 1,
      int pageSize = 10,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Customers.Get
      {
        PageNumber = page,
        PageSize = pageSize
      };

      var result = await customerHandler.GetCustomersAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.BadRequest();
    });
  }
}
