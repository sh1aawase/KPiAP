using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class FinanceService
    {
        public async Task<List<Transaction>> GetTransactionsFromApiAsync()
        {
            await Task.Delay(3000); 
            return new List<Transaction>
            {
                new Transaction { Date = DateTime.Now, Category = "Еда", Amount = 1500 },
                new Transaction { Date = DateTime.Now, Category = "Транспорт", Amount = 500 },
                new Transaction { Date = DateTime.Now.AddDays(-1), Category = "Досуг", Amount = 3000 }
            };
        }

        public List<CategoryModel> CalculateStatistics(IEnumerable<Transaction> transactions)
        {
            var total = transactions.Sum(t => t.Amount);
            if (total == 0) return new List<CategoryModel>();

            return transactions
                .GroupBy(t => t.Category)
                .Select(g => new CategoryModel
                {
                    Name = g.Key,
                    TotalAmount = g.Sum(t => t.Amount),
                    Percentage = (double)(g.Sum(t => t.Amount) / total) * 100
                }).ToList();
        }
    }
}