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
            affiliated.AffiliatedId = _affiliated.AffiliatedId;
            return affiliated;
        }
        public async Task<AffiliatedDto> Remove(AffiliatedDto affiliated)
        {
            var _affiliated = _rep.GetByName(affiliated.Name).Result;
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
            var affiliateds = await _rep.GetAffiliateds();
            return _map.Map<IEnumerable<AffiliatedDto>>(affiliateds);
        }

        public async Task<AffiliatedDto> GetByName(string Name)
        {
            var affiliated = await _rep.GetByName(Name);
            return _map.Map<AffiliatedDto>(affiliated);
        }
        
    }
}
