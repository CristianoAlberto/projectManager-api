using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagerApi.src.Application.Interfaces;
using ProjectManagerApi.src.Application.Services;
using ProjectManagerApi.src.Domain.Interfaces;
using ProjectManagerApi.src.Infrastructure.Persistence.Repositories;

namespace ProjectManagerApi.src.Infrastructure.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;
        }
    }
}