using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using CoodeshTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CoodeshTest.Infra.Data.Repositories
{
    public class CreatorRepository : ICreatorRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CreatorRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Creator> Add(Creator creator)
        {
            _ctx.Add(creator);
            await _ctx.SaveChangesAsync();
            return creator;
        }
        public async Task<Creator> Remove(Creator creator)
        {
            _ctx.Remove(creator);
            await _ctx.SaveChangesAsync();
            return creator;
        }

        public async Task<Creator> Update(Creator creator)
        {
            _ctx.Update(creator);
            await _ctx.SaveChangesAsync();
            return creator;
        }

        public async Task<Creator> GetById(int? creatorId)
        {
            return await _ctx.Creators.FindAsync(creatorId);
        }

        public async Task<IEnumerable<Creator>> GetCreatorsAsync()
        {
            return await _ctx.Creators.ToListAsync();
        }
        
    }
}
