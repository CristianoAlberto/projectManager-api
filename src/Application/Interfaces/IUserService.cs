using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Application.Common.Responses;
using ProjectManagerApi.src.Application.DTOs.User;

namespace ProjectManagerApi.src.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserResponseDTO>> GetByIdAsync(int id);
        Task<Result<UserResponseDTO>> GetByEmailAsync(string email);
        Task<Result<IEnumerable<UserResponseDTO>>> GetAll();
        Task<Result<UserResponseDTO>> AddUserAsync(UserRequestDTO user);
    }
}