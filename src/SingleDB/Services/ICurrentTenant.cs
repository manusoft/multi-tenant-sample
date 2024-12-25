namespace SingleDB.Services;

public interface ICurrentTenant
{
    string TenantId { get; set; }
    Task<bool> SetTenant(string tenantId);
}
