using CoodeshTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Interfaces
{
    public interface IAffiliatedService
    {
        Task<IEnumerable<AffiliatedDto>> GetAffiliateds();
        Task<AffiliatedDto> GetByName(string? Name);
        Task<AffiliatedDto> Add(AffiliatedDto affiliated);
        Task<AffiliatedDto> Update(AffiliatedDto affiliated);
        Task<AffiliatedDto> Remove(AffiliatedDto affiliated);
    }
}
