﻿using CoodeshTest.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoodeshTest.Application.Interfaces
{
    public interface ICollaboratorService
    {
        Task<IEnumerable<CollaboratorDto>> GetCollaborator(CollaboratorDto collaborator);
        Task<CollaboratorDto> GetByEmail(string? collaboratorEmail);
        Task<CollaboratorDto> Add(CollaboratorDto collaborator);
        Task<CollaboratorDto> Update(CollaboratorDto collaborator);
        Task<CollaboratorDto> Remove(CollaboratorDto collaborator);
    }
}
