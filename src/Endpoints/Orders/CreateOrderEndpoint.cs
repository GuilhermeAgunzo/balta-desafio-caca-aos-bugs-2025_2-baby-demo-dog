using BugStore.Abstractions.Handlers.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Orders;

public static class CreateOrderEndpoint
{
  public static void MapCreateOrder(this WebApplication app)
  {
    app.MapPost("/orders", async (
      [FromServices] IHandler handler,
      Requests.Orders.Create request,
      CancellationToken cancellationToken = default) =>
    {
      var result = await handler.CreateOrderAsync(request, cancellationToken);
      return result.IsSuccess
        ? Results.Created($"/orders/{result.Data?.Id}", result)
        : Results.BadRequest();
    });
  }
}
