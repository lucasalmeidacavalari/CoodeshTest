using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Interfaces
{
    public interface ITransaction
    {
        Task<IEnumerable<Transaction>> GetProducts();
        Task<Transaction> GetById(int? transactionId);
        Task<Transaction> Add(Transaction transaction);
        Task<Transaction> Update(Transaction transaction);
        Task<Transaction> Remove(Transaction transaction);
    }
}
