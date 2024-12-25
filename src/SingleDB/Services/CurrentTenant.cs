using SingleDB.Data;

namespace SingleDB.Services;

public class CurrentTenant(TenantDbContext context) : ICurrentTenant
{
    public string TenantId { get; set; } = default!;

    public async Task<bool> SetTenant(string tenantId)
    {
        var existTenant = await context.Tenants.FindAsync(tenantId);
        if (existTenant == null)
            throw new Exception(tenantId + " not found");

        TenantId = existTenant.Id;
        return true;
    }
}