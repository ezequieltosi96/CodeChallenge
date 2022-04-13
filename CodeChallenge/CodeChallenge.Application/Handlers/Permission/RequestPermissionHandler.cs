using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Interfaces.ElasticSearch;
using CodeChallenge.Application.Interfaces.Mapping;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.UnitOfWork;

namespace CodeChallenge.Application.Handlers.Permission
{
    public class RequestPermissionHandler : ICommandHandler<RequestPermissionCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;
        private readonly IElasticClient _elasticClient;

        public RequestPermissionHandler(IUnitOfWork unitOfWork, IMapping mapping, IElasticClient elasticClient)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
            _elasticClient = elasticClient;
        }

        public string Handle(RequestPermissionCommand command)
        {
            Domain.Entities.PermissionType permissionType = _unitOfWork.PermissionTypes.GetById(command.IdPermissionType.Value);

            if (permissionType == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.PermissionType), command.IdPermissionType.Value);
            }

            Domain.Entities.Permission permission = _mapping.Map<Domain.Entities.Permission>(command);

            _unitOfWork.Permissions.Create(permission);

            _unitOfWork.Commit();

            _elasticClient.IndexDocument<Domain.Entities.Permission>(permission);

            return $"Permission \"{permissionType.Description}\" granted to {permission.EmployeeForename} {permission.EmployeeSurname} on {permission.PermissionDate.ToShortDateString()} UTC. Permission ID: {permission.Id}.";
        }
    }
}
