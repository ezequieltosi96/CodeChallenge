using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Interfaces.ElasticSearch;
using CodeChallenge.Application.Interfaces.Mapping;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.UnitOfWork;

namespace CodeChallenge.Application.Handlers.Permission
{
    public class ModifyPermissionHandler : ICommandHandler<ModifyPermissionCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;
        private readonly IElasticClient _elasticClient;

        public ModifyPermissionHandler(IUnitOfWork unitOfWork, IMapping mapping, IElasticClient elasticClient)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
            _elasticClient = elasticClient;
        }

        public string Handle(ModifyPermissionCommand command)
        {
            Domain.Entities.Permission permission = _unitOfWork.Permissions.GetById(command.Id.Value);

            if (permission == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Permission), command.Id.Value);
            }

            Domain.Entities.PermissionType permissionType = _unitOfWork.PermissionTypes.GetById(command.IdPermissionType.Value);

            if (permissionType == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.PermissionType), command.IdPermissionType.Value);
            }

            _mapping.Map(command, permission);

            _unitOfWork.Permissions.Update(permission);

            _unitOfWork.Commit();

            _elasticClient.UpdateDocument<Domain.Entities.Permission>(permission);

            return $"Permission ID: {permission.Id} successfully modified.";
        }
    }
}
