using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using CoodeshTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Infra.Data.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CollaboratorRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Collaborator> Add(Collaborator collaborator)
        {
            _ctx.Add(collaborator);
            await _ctx.SaveChangesAsync();
            return collaborator;
        }
        public async Task<Collaborator> Remove(Collaborator collaborator)
        {
            _ctx.Remove(collaborator);
            await _ctx.SaveChangesAsync();
            return collaborator;
        }

        public async Task<Collaborator> Update(Collaborator collaborator)
        {
            _ctx.Update(collaborator);
            await _ctx.SaveChangesAsync();
            return collaborator;
        }

        public async Task<Collaborator> GetById(int? collaboratorId)
        {
            return await _ctx.Collaborators.FindAsync(collaboratorId);
        }

        public async Task<IEnumerable<Collaborator>> GetCollaborator()
        {
            return await _ctx.Collaborators.ToListAsync();
        }
        
    }
}
