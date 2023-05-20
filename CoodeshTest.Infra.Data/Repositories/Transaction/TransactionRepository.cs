using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using CoodeshTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CoodeshTest.Infra.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _ctx;

        public TransactionRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Transaction> Add(Transaction transaction)
        {
            _ctx.Add(transaction);
            await _ctx.SaveChangesAsync();
            return transaction;
        }
        public async Task<Transaction> Remove(Transaction transaction)
        {
            _ctx.Remove(transaction);
            await _ctx.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> Update(Transaction transaction)
        {
            _ctx.Update(transaction);
            await _ctx.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> GetById(int? transactionId)
        {
            return await _ctx.Transactions.Include(_ => _.Creator).Include(_ => _.Product).Include(_ => _.Affiliated).Where(_ => _.TransactionId == transactionId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _ctx.Transactions.Include(_ => _.Creator).Include(_ => _.Product).Include(_ => _.Affiliated).ToListAsync();
        }
        
    }
}
