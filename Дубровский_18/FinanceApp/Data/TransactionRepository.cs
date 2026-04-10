using Microsoft.EntityFrameworkCore;
using FinanceApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceApp.Data
{
    public class TransactionRepository
    {
        private readonly FinanceContext _context;

        public TransactionRepository(FinanceContext context) => _context = context;

        public async Task<List<Transaction>> GetTransactionsAsync() =>
            await _context.Transactions.ToListAsync();

        public async Task AddTransactionAsync(Transaction t) =>
            await _context.Transactions.AddAsync(t);

        public async Task DeleteTransactionAsync(Transaction t)
        {
            _context.Transactions.Remove(t);
            await Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}