using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.src.Domain.Entities;
using ProjectManagerApi.src.Domain.Interfaces;

namespace ProjectManagerApi.src.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Project> AddAsync(Project project)
        {
            await _dbContext.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }
        public async Task<Project?> DeleteAsync(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project == null) return null;
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            IEnumerable<Project> projects = await _dbContext.Projects.ToListAsync();
            return projects;
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project == null) return null;
            return project;
        }
        public async Task<Project?> UpdateAsync(int id, Project project)
        {
            var findProject = await _dbContext.Projects.FindAsync(id);
            if (findProject == null) return null;
            findProject.Name = project.Name;
            findProject.Description = project.Description;
            _dbContext.Projects.Update(findProject);
            await _dbContext.SaveChangesAsync();
            return findProject;
        }
    }
}