using BugStore.Abstractions.Handlers.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Orders;

public static class GetOrderByIdEndpoint
{
  public static void MapGetOrderByIdEndpoint(this WebApplication app)
  {
    app.MapGet("/orders/{id}", async (
      [FromServices] IHandler handler,
      Guid id,
      CancellationToken cancellationToken = default) =>
    {
      var request = new Requests.Orders.GetById { Id = id };
      var result = await handler.GetOrderByIdAsync(request, cancellationToken);
      return result.IsSuccess
        ? Results.Ok(result)
        : Results.BadRequest();
    });
  }
}
