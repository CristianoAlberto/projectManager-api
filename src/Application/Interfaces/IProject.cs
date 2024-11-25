using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Application.Common.Responses;
using ProjectManagerApi.src.Application.DTOs.Project;

namespace ProjectManagerApi.src.Application.Interfaces
{
    public interface IProject
    {
        Task<Result<IEnumerable<ProjectResponseDTO>>> GetAllAsync();
        Task<Result<ProjectResponseDTO>> GetByIdAsync(int id);
        Task<Result<ProjectResponseDTO>> AddAsync(ProjectRequestDTO projectRequestDTO);
        Task<Result<ProjectResponseDTO>> UpdateAsync(int id, ProjectRequestDTO projectRequestDTO);
        Task<Result<ProjectResponseDTO>> DeleteAsync(int id);

    }
}