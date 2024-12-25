using Microsoft.EntityFrameworkCore;
using SingleDB.Models;

namespace SingleDB.Data;

public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();   
}