using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Application.Interfaces.Repositories.Base;
using CodeChallenge.Cross.Constants;
using CodeChallenge.Persistence.Repositories;
using CodeChallenge.Persistence.Repositories.Base;
using CodeChallenge.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CodeChallenge.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<CodeChallengeDbContext>(opts => opts.UseSqlServer(Environment.GetEnvironmentVariable(EnvironmentKeys.KEY_CONNECTION_STRING)));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();

            return services;
        }
    }
}
