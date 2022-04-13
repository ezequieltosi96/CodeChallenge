using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Handlers.Permission;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.Mediator.Query;
using CodeChallenge.Application.Queries.Permission;
using CodeChallenge.Domain.DTO.Permission;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CodeChallenge.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            //TODO: register by name convention

            // QueryHandler registration
            services.AddTransient<IQueryHandler<GetPermissionQuery, IList<PermissionDto>>, GetAllPermissionHandler>();

            // CommandHandler registration
            services.AddTransient<ICommandHandler<ModifyPermissionCommand, string>, ModifyPermissionHandler>();
            services.AddTransient<ICommandHandler<RequestPermissionCommand, string>, RequestPermissionHandler>();

            return services;
        }
    }
}
