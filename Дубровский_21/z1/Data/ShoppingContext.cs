using Microsoft.EntityFrameworkCore;
using z1.Models;

namespace z1.Data;

public class ShoppingContext : DbContext
{
    public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
    {
    }

    public DbSet<ShoppingItem> ShoppingItems => Set<ShoppingItem>();
}
