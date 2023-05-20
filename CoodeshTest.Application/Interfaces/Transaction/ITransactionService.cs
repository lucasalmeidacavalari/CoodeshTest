using CoodeshTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactions();
        Task<TransactionDto> GetById(int? transactionId);
        Task<TransactionDto> Add(TransactionDto transaction);
        Task<TransactionDto> Update(TransactionDto transaction);
        Task<TransactionDto> Remove(TransactionDto transaction);
    }
}
