using ProjectManagerApi.src.Application.DTOs.User;
using ProjectManagerApi.src.Application.Interfaces;
using ProjectManagerApi.src.Domain.Interfaces;
using ProjectManagerApi.src.Domain.Entities;
using ProjectManagerApi.src.Application.Common.Responses;

namespace ProjectManagerApi.src.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<UserResponseDTO>> AddUserAsync(UserRequestDTO userDTO)
        {
            var userEntity = new User
            {
                Email = userDTO.Email,
                Name = userDTO.Name
            };
            await _userRepository.AddUserAsync(userEntity);
            return Result<UserResponseDTO>.Success(new UserResponseDTO { Email = userEntity.Email, Name = userEntity.Name, Id = userEntity.Id });
        }
        public async Task<Result<IEnumerable<UserResponseDTO>>> GetAll()
        {
            var users = await _userRepository.GetAll();
            if (users.Count() < 0) return Result<IEnumerable<UserResponseDTO>>.Failure("Users not found");
            var userDTOs = users.Select(user => new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });
            return Result<IEnumerable<UserResponseDTO>>.Success(userDTOs);
        }
        public async Task<Result<UserResponseDTO>> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return Result<UserResponseDTO>.Failure("User not found");
            return Result<UserResponseDTO>.Success(new UserResponseDTO { Email = user.Email, Name = user.Name, Id = user.Id });
        }
        public async Task<Result<UserResponseDTO>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return Result<UserResponseDTO>.Failure("User not found");
            return Result<UserResponseDTO>.Success(new UserResponseDTO { Email = user.Email, Name = user.Name, Id = user.Id });
        }
    }
}