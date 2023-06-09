﻿using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<IEnumerable<Transaction>> GetById(int? transactionId, string name);
        Task<Transaction> Add(Transaction transaction);
        Task<Transaction> Update(Transaction transaction);
        Task<Transaction> Remove(Transaction transaction);
    }
}
