using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetCollaborator();
        Task<Collaborator> GetById(int? collaboratorId);
        Task<Collaborator> Add(Collaborator collaborator);
        Task<Collaborator> Update(Collaborator collaborator);
        Task<Collaborator> Remove(Collaborator collaborator);
    }
}
