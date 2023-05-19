using CoodeshTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Domain.Interfaces
{
    public interface ICreatorRepository
    {
        Task<IEnumerable<Creator>> GetCreatorsAsync();
        Task<Creator> GetById(int? creatorId);
        Task<Creator> Add(Creator creator);
        Task<Creator> Update(Creator creator);
        Task<Creator> Remove(Creator creator);
    }
}
