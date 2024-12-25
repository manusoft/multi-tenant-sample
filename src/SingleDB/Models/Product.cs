namespace SingleDB.Models;

public class Product : IHasTenant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TenantId { get; set; }
}
