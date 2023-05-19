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
    public class AffiliatedRepository : IAffiliatedRepository
    {
        private readonly ApplicationDbContext _ctx;

        public AffiliatedRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Affiliated> Add(Affiliated affiliated)
        {
            _ctx.Add(affiliated);
            await _ctx.SaveChangesAsync();
            return affiliated;
        }
        public async Task<Affiliated> Remove(Affiliated affiliated)
        {
            _ctx.Remove(affiliated);
            await _ctx.SaveChangesAsync();
            return affiliated;
        }

        public async Task<Affiliated> Update(Affiliated affiliated)
        {
            _ctx.Update(affiliated);
            await _ctx.SaveChangesAsync();
            return affiliated;
        }

        public async Task<IEnumerable<Affiliated>> GetAffiliateds()
        {
            return await _ctx.Affiliates.ToListAsync();
        }

        public async Task<Affiliated> GetById(int? affiliatedId)
        {
            return await _ctx.Affiliates.FindAsync(affiliatedId);
        }

    }
}
