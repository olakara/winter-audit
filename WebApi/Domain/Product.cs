namespace WebApi.Domain;

public class Product : IEntity
{
    
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public Category Category { get; set; }
    
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
    
}