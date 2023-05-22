using AutoMapper;
using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.App
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _rep;
        private readonly IMapper _map;

        public TransactionService(ITransactionRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        public async Task<TransactionDto> Add(TransactionDto transaction)
        {
            var _transaction = _map.Map<Transaction>(transaction);
            await _rep.Add(_transaction);
            return transaction;
        }
        public async Task<TransactionDto> Remove(TransactionDto transaction)
        {
            return null;
        }

        public async Task<TransactionDto> Update(TransactionDto transaction)
        {
            var _transaction = _map.Map<Transaction>(transaction);
            await _rep.Update(_transaction);
            return transaction;
        }

        public async Task<IEnumerable<TransactionDto>> GetById(int? transactionId, string name)
        {
            var _transaction = await _rep.GetById(transactionId, name);
            return _map.Map<IEnumerable<TransactionDto>>(_transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactions()
        {
            var _transaction = await _rep.GetTransactions();
            return _map.Map<IEnumerable<TransactionDto>>(_transaction);
        }
       
    }
}
