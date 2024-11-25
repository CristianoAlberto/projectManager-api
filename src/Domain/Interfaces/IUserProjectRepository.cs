using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Domain.Entities;

namespace ProjectManagerApi.src.Domain.Interfaces
{
    public interface IUserProjectRepository
    {
        Task<IEnumerable<UserProject>> GetAll();
        Task<IEnumerable<UserProject>> GetAllByUserId(int userId);
        Task<IEnumerable<UserProject>> GetAllByProjectId(int projectId);
        Task<UserProject> AddAsync(UserProject userProject);
        Task<UserProject> UpdateAsync(int id, UserProject userProject);
        Task<UserProject> DeleteAsync(int id);

    }
}