namespace WebApi.Domain;

public class Category : IEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
}