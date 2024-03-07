using Budgetizer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Budgetizer.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DataContext() { } // Empty constructor needed for testing
    }
}
