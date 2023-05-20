using CoodeshTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Interfaces
{
    public interface ICreatorService
    {
        Task<IEnumerable<CreatorDto>> GetCreatorsAsync();
        Task<CreatorDto> GetById(int? creatorId);
        Task<CreatorDto> Add(CreatorDto creator);
        Task<CreatorDto> Update(CreatorDto creator);
        Task<CreatorDto> Remove(CreatorDto creator);
    }
}
