using CoodeshTest.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Entities
{
    public sealed class Affiliated
    {
        public int AffiliatedId { get; private set; }
        public string Name { get; private set; }

        public Affiliated(string name)
        {
            ValidateDomain(name);
        }

        public Affiliated(int affiliatedId, string name)
        {
            DomainExceptionValidation.When(affiliatedId < 0, "Invalid id value");
            AffiliatedId = affiliatedId;
            Name = name;
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
