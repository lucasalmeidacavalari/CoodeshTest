using CoodeshTest.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Entities
{
    public sealed class Creator
    {
        public int CreatorId { get; private set; }
        public string Name { get; private set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }

        public Creator(string name)
        {
            ValidateDomain(name);
        }

        public Creator(int creatorId, string name)
        {
            DomainExceptionValidation.When(creatorId < 0, "Invalid id value");
            CreatorId = creatorId;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. minimium 3 charecters");

            Name = name;
        }
    }
}
