using Budgetizer.Entities.Enums;

namespace Budgetizer.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Title { get; set; } = string.Empty;
        public Interval Interval{ get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}