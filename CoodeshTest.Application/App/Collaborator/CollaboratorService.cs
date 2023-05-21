using AutoMapper;
using CoodeshTest.Application.Dto;
using CoodeshTest.Application.Interfaces;
using CoodeshTest.Domain.Entities;
using CoodeshTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.App
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _rep;
        private readonly IMapper _map;

        public CollaboratorService(ICollaboratorRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        public async Task<CollaboratorDto> Add(CollaboratorDto collaborator)
        {
            var _collaborator = _map.Map<Collaborator>(collaborator);
            await _rep.Add(_collaborator);
            return collaborator;
        }
        public async Task<CollaboratorDto> Remove(CollaboratorDto collaborator)
        {
            var _collaborator = _rep.GetById(collaborator.CollaboratorId).Result;
            await _rep.Remove(_collaborator);
            return collaborator;
        }

        public async Task<CollaboratorDto> Update(CollaboratorDto collaborator)
        {
            var _collaborator = _map.Map<Collaborator>(collaborator);
            await _rep.Update(_collaborator);
            return collaborator;
        }

        public async Task<CollaboratorDto> GetById(int? collaboratorId)
        {
            var _collaborator = await _rep.GetById(collaboratorId);
            return _map.Map<CollaboratorDto>(_collaborator);
        }

        public async Task<IEnumerable<CollaboratorDto>> GetCollaborators()
        {
            var collaborator = await _rep.GetCollaborator();
            return _map.Map<IEnumerable<CollaboratorDto>>(collaborator);
        }
        
    }
}
