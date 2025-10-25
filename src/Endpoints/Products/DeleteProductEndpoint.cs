using System;
using BugStore.Abstractions.Handlers.Products;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Products;

public static class DeleteProductEndpoint
{
  public static void MapDeleteProduct(this IEndpointRouteBuilder routes)
  {
    routes.MapDelete("/v1/products/{id}", async Task<IResult> (
      [FromServices] IHandler productHandler,
      Guid id,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Products.Delete
      {
        Id = id
      };

      var result = await productHandler.DeleteProductAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.NoContent()
        : TypedResults.NotFound();
    });
  }
}
