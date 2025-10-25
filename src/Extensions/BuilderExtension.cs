using System;

namespace BugStore.Extensions;

public static class BuilderExtension
{
  public static void AddServices(this WebApplicationBuilder builder)
  {
    builder.Services.AddTransient<Abstractions.Handlers.Customers.IHandler, Handlers.Customers.Handler>();
    builder.Services.AddTransient<Abstractions.Handlers.Products.IHandler, Handlers.Products.Handler>();
  }
}
