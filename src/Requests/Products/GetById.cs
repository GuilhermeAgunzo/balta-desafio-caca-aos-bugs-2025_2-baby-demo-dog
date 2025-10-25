namespace BugStore.Requests.Products;

public class GetById : Request
{
  public Guid Id { get; set; }
}