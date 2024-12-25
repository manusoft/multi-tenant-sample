namespace SingleDB.Models;

public interface IHasTenant
{
    string TenantId { get; set; }
}