using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Domain.Entities;

namespace ProjectManagerApi.src.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAll();
        Task<User?> AddUserAsync(User user);
        Task<User?> UpdateUserAsync(int id, User user);
        Task<User?> DeleteUserAsync(int id);

    }
}