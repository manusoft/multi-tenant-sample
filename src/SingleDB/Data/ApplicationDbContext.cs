using Microsoft.EntityFrameworkCore;
using SingleDB.Models;
using SingleDB.Services;

namespace SingleDB.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentTenant currentTenant) : DbContext(options)
{
    public string CurrentTenantId => currentTenant.TenantId;

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Product> Products => Set<Product>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<IHasTenant>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                case EntityState.Modified:
                    entry.Entity.TenantId = CurrentTenantId;
                    break;
            }
        }

        return base.SaveChanges();
    }
}
