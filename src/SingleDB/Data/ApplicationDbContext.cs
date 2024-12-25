using Microsoft.EntityFrameworkCore;
using SingleDB.Models;

namespace SingleDB.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Product> Products => Set<Product>();
}
