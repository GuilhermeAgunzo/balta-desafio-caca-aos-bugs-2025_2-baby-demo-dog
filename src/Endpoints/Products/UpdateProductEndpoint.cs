using System;
using BugStore.Abstractions.Handlers.Products;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Products;

public static class UpdateProductEndpoint
{
  public static void MapUpdateProduct(this IEndpointRouteBuilder routes)
  {
    routes.MapPut("/v1/products/{id}", async Task<IResult> (
      [FromServices] IHandler productHandler,
      Guid id,
      Requests.Products.Update request,
      CancellationToken cancellationToken = default) =>
    {
      request.Id = id;

      var result = await productHandler.UpdateProductAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.NotFound();
    });
  }

}
