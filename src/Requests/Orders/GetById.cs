namespace BugStore.Requests.Orders;

public class GetById : Request
{
  public Guid Id { get; set; }
}