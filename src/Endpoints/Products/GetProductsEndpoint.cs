using System;
using BugStore.Abstractions.Handlers.Products;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Products;

public static class GetProductsEndpoint
{
  public static void MapGetProductsEndpoint(this WebApplication app)
  {
    app.MapGet("/products", async Task<IResult> (
      [FromServices] IHandler handler,
      int pageNumber = 1,
      int pageSize = 10,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Products.Get
      {
        PageNumber = pageNumber,
        PageSize = pageSize
      };

      var result = await handler.GetProductsAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.BadRequest();
    });
  }
}
