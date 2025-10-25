namespace BugStore.Requests.Products;

public class Delete : Request
{
  public required Guid Id { get; set; }
}