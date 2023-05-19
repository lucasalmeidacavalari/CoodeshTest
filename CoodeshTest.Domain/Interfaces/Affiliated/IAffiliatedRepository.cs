using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Interfaces
{
    public interface IAffiliatedRepository
    {
        Task<IEnumerable<Affiliated>> GetAffiliateds();
        Task<Affiliated> GetById(int? affiliatedId);
        Task<Affiliated> Add(Affiliated affiliated);
        Task<Affiliated> Update(Affiliated affiliated);
        Task<Affiliated> Remove(Affiliated affiliated);

    }
}
