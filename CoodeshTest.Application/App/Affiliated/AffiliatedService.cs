using AutoMapper;
using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;

namespace CoodeshTest.Application.App
{
    public class AffiliatedService : IAffiliatedService
    {
        private readonly IAffiliatedRepository _rep;
        private readonly IMapper _map;

        public AffiliatedService(IAffiliatedRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }
        public async Task<AffiliatedDto> Add(AffiliatedDto affiliated)
        {
            var _affiliated = _map.Map<Affiliated>(affiliated);
            await _rep.Add(_affiliated);
            return affiliated;
        }
        public async Task<AffiliatedDto> Remove(AffiliatedDto affiliated)
        {
            var _affiliated = _rep.GetById(affiliated.AffiliatedId).Result;
            await _rep.Remove(_affiliated);
            return affiliated;
        }

        public async Task<AffiliatedDto> Update(AffiliatedDto affiliated)
        {
            var _affiliated = _map.Map<Affiliated>(affiliated);
            await _rep.Update(_affiliated);
            return affiliated;
        }

        public async Task<IEnumerable<AffiliatedDto>> GetAffiliateds()
        {
            var affiliateds = _rep.GetAffiliateds();
            return _map.Map<IEnumerable<AffiliatedDto>>(affiliateds);
        }

        public async Task<AffiliatedDto> GetById(int? affiliatedId)
        {
            var affiliateds = _rep.GetById(affiliatedId);
            return _map.Map<AffiliatedDto>(affiliateds);
        }
        
    }
}
