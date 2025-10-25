using System;
using BugStore.Abstractions.Handlers.Products;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Products;

public static class CreateProductEndpoint
{
  public static void MapCreateProduct(this IEndpointRouteBuilder routes)
  {
    routes.MapPost("/v1/products", async Task<IResult> (
      [FromServices] IHandler productHandler,
      Requests.Products.Create request,
      CancellationToken cancellationToken = default) =>
    {
      var result = await productHandler.CreateProductAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Created($"/v1/products/{result.Data?.Id}", result)
        : TypedResults.BadRequest();
    });
  }

}
