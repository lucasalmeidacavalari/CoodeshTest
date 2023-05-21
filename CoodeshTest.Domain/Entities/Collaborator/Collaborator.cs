using CoodeshTest.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoodeshTest.Domain.Entities
{
    public class Collaborator
    {
        public int CollaboratorId { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Collaborator(string email, string password)
        {
            ValidateDomain(email, password);
        }

        public Collaborator(int collaboratorId, string email, string password)
        {
            DomainExceptionValidation.When(collaboratorId < 0, "Invalid id value");
            CollaboratorId = collaboratorId;
            Email = email;
            Password = password;
        }

        public void Update(string email, string password)
        {
            ValidateDomain(email, password);
        }

        private void ValidateDomain(string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid email. E-mail is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Invalid password. Password is required");

            Email = email;
            Password = password;
        }
    }
}
