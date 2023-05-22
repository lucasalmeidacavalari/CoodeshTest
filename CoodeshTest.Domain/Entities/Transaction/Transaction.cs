using CoodeshTest.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoodeshTest.Domain.Entities
{
    public sealed class Transaction
    {
        public int TransactionId { get; private set; }
        public DateTime DateTransaction { get; private set; }
        public decimal Price { get; private set; }
        public int Type { get; set; }
        public int? CreatorId { get; set; }
        public Creator? Creator { get; set; }
        public int? AffiliatedId { get; set; }
        public Affiliated? Affiliated { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public Transaction(DateTime dateTransaction, decimal price)
        {
            ValidateDomain(dateTransaction, price);
        }

        public Transaction(int transactionId, DateTime dateTransaction, decimal price)
        {
            DomainExceptionValidation.When(transactionId < 0, "Invalid id value");
            TransactionId = transactionId;
            ValidateDomain(dateTransaction, price);
        }
        public void Update(DateTime dateTransaction, decimal price, int creatorId, int affiliatedId, int productId)
        {
            ValidateDomain(dateTransaction, price);
            CreatorId = creatorId;
            AffiliatedId = affiliatedId;
            ProductId = productId;
        }

        private void ValidateDomain(DateTime dateTransaction, decimal price)
        {
            DomainExceptionValidation.When(dateTransaction == DateTime.MinValue || !ValidateDateFormat(dateTransaction.ToString()),
                "Invalid date. Date is required or has an invalid format.");
            DomainExceptionValidation.When(price < 0,
                "Invalid price value.");

            DateTransaction = dateTransaction;
            Price = price;
        }

        private bool ValidateDateFormat(string date)
        {
            DateTime parsedDate;
            return DateTime.TryParse(date, out parsedDate);
        }
       
    }
}
