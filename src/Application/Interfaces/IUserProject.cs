using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Application.Common.Responses;
using ProjectManagerApi.src.Application.DTOs.UserProject;

namespace ProjectManagerApi.src.Application.Interfaces
{
    public interface IUserProject
    {
        Task<Result<IEnumerable<UserProjectResponseDTO>>> GetAllUserProjectAsync();
        Task<Result<IEnumerable<UserProjectResponseDTO>>> GetAllUserProjectByUserIdAsync(int id);
        Task<Result<IEnumerable<UserProjectResponseDTO>>> GetAllUserProjectByProjectIdAsync(int id);
        Task<Result<UserProjectResponseDTO>> AddAsync(UserProjectRequestDTO userProjectRequestDTO);
        Task<Result<UserProjectResponseDTO>> UpdateAsync(int id, UserProjectRequestDTO userProjectRequestDTO);
        Task<Result<UserProjectResponseDTO>> DeleteAsync(int id);
    }
}