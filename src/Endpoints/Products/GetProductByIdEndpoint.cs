using BugStore.Abstractions.Handlers.Products;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Products;

public static class GetProductByIdEndpoint
{
  public static void MapGetProductById(this IEndpointRouteBuilder routes)
  {
    routes.MapGet("/v1/products/{id}", async Task<IResult> (
      [FromServices] IHandler productHandler,
      Guid id,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Products.GetById
      {
        Id = id
      };

      var result = await productHandler.GetProductByIdAsync(request, cancellationToken);

      return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.NotFound();
    });
  }

}
