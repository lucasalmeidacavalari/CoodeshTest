using AutoMapper;
using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;

namespace CoodeshTest.Application.App
{
    public class CreatorService : ICreatorService
    {
        private readonly ICreatorRepository _rep;
        private readonly IMapper _map;

        public CreatorService(ICreatorRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }
        public async Task<CreatorDto> Add(CreatorDto creator)
        {
            var _creator = _map.Map<Creator>(creator);
            await _rep.Add(_creator);
            creator.CreatorId = _creator.CreatorId;
            return creator;
        }
        public async Task<CreatorDto> Remove(CreatorDto creator)
        {
            var _creator = _rep.GetByName(creator.Name).Result;
            await _rep.Remove(_creator);
            return creator;
        }

        public async Task<CreatorDto> Update(CreatorDto creator)
        {
            var _creator = _map.Map<Creator>(creator);
            await _rep.Update(_creator);
            return creator;
        }

        public async Task<CreatorDto> GetByName(string Name)
        {
            var creator = await _rep.GetByName(Name);
            return _map.Map<CreatorDto>(creator);
        }

        public async Task<IEnumerable<CreatorDto>> GetCreatorsAsync()
        {
            var creators = await _rep.GetCreatorsAsync();
            return _map.Map<IEnumerable<CreatorDto>>(creators);
        }
        
    }
}
