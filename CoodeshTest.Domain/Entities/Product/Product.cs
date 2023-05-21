using CoodeshTest.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Entities
{
    public sealed class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int? CreatorId { get; set; }
        public Creator? Creator { get; set; }
        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }

        public Product(string name, decimal price)
        {
            ValidateDomain(name, price);
        }

        public Product(int productId, string name, decimal price)
        {
            DomainExceptionValidation.When(productId < 0, "Invalid id value");
            ProductId = productId;
            ValidateDomain(name, price);
        }
        public void Update(string name, decimal price, int creatorId)
        {
            ValidateDomain(name, price);
            CreatorId = creatorId;
        }

        private void ValidateDomain(string name, decimal price)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, 
                "Invalid name. minimium 3 charecters");
            DomainExceptionValidation.When(price < 0,
                "Invalid price value.");

            Name = name;
            Price = price;
        }
    }
}
