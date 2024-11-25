using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.src.Domain.Entities;
using ProjectManagerApi.src.Domain.Interfaces;

namespace ProjectManagerApi.src.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<User?> AddUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var findUser = await this.GetByEmailAsync(user.Email);
            if (findUser != null) return null;
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var findUser = await _dbcontext.Users.FindAsync(id);
            if (findUser == null) return null;
            _dbcontext.Users.Remove(findUser);
            await _dbcontext.SaveChangesAsync();
            return findUser;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _dbcontext.Users.ToListAsync();
            return users;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _dbcontext.Users.FindAsync(email);
            if (user == null) return null;
            return user;
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user == null) return null;
            return user;
        }

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var findUser = await _dbcontext.Users.FindAsync(id);
            var findUserByEmail = await _dbcontext.Users.FindAsync(user.Email);
            if (findUser == null) return null;
            if (findUserByEmail == null) return null;
            findUser.Name = user.Name;
            findUser.Email = user.Email;
            _dbcontext.Users.Update(findUser);
            return findUser;
        }
    }
}