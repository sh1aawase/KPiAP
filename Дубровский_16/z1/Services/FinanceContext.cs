using Microsoft.EntityFrameworkCore;
using z1.Models;

namespace z1.Services
{
    public class FinanceContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=finance.db");
        }
    }
}