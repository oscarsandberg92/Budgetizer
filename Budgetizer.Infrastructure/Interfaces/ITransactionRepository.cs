using Budgetizer.Entities;

namespace Budgetizer.Infrastructure.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransaction(Transaction transaction); 
        Task<Transaction?> GetTransaction(int transactionId); 
        Task<List<Transaction>> GetTransactions(); 
        Task<bool> DeleteTransaction(int transactionId);
    }
}
