using System;
using BugStore.Abstractions.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customers;

public static class GetCustomerByIdEndpoint
{
  public static void MapGetCustomerById(this IEndpointRouteBuilder routes)
  {
    routes.MapGet("/v1/customers/{id}", async Task<IResult> (
      [FromServices] IHandler customerHandler,
      Guid id,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Customers.GetById
      {
        Id = id
      };

      var result = await customerHandler.GetCustomerByIdAsync(request, cancellationToken);
      return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.BadRequest();
    });
  }

}
