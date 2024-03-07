using Budgetizer.Entities;
using Budgetizer.Infrastructure.Data;
using Budgetizer.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Budgetizer.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            await _context.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<bool> DeleteTransaction(int transactionId)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);

            if (transaction == null) return false;

            var result =  _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Transaction?> GetTransaction(int transactionId)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _context.Transactions.OrderByDescending(x => x.Amount).ToListAsync();
        }
    }
}
