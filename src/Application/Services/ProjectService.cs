using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Application.Common.Responses;
using ProjectManagerApi.src.Application.DTOs.Project;
using ProjectManagerApi.src.Application.Interfaces;

namespace ProjectManagerApi.src.Application.Services
{
    public class ProjectService : IProject
    {
        private readonly IProject _project;

        public Task<Result<ProjectResponseDTO>> AddAsync(ProjectRequestDTO projectRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProjectResponseDTO>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ProjectResponseDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProjectResponseDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProjectResponseDTO>> UpdateAsync(int id, ProjectRequestDTO projectRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}