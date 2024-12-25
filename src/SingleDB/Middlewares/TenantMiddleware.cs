using SingleDB.Services;

namespace SingleDB.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;
    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, ICurrentTenant currentTenant)
    {
        context.Request.Headers.TryGetValue("X-Tenant", out var tenant);
        if (!string.IsNullOrEmpty(tenant))
        {
            //Set tenant in scoped service
            await currentTenant.SetTenant(tenant);
        }
        await _next(context);
    }
}
