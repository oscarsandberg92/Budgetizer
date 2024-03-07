using Budgetizer.Entities;
using Budgetizer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Budgetizer.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController: ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> AddTransaction(Transaction transaction)
        {
            var result = await _transactionRepository.AddTransaction(transaction);

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetTransactions()
        {
            var result = await _transactionRepository.GetTransactions();

            return result;
        }

        [HttpGet("{transactionId}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int transactionId)
        {
            var result = await _transactionRepository.GetTransaction(transactionId);
            if (result is null) return NotFound();
            return result;
        }

        [HttpDelete("{transactionId}")]
        public async Task<ActionResult> DeleteTransaction(int transactionId)
        {
            var result = await _transactionRepository.DeleteTransaction(transactionId);

            return result ? NotFound() : BadRequest("Not found");
        }
    }
}
