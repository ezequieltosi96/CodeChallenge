using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.Services;

namespace CodeChallenge.Application.Handlers.Permission
{
    public class ModifyPermissionHandler : ICommandHandler<ModifyPermissionCommand, int>
    {
        private readonly IPermissionService _permissionService;
        
        public ModifyPermissionHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public int Handle(ModifyPermissionCommand command)
        {
            return _permissionService.Update(command.Id.Value, command.IdPermissionType.Value, command.EmployeeForename, command.EmployeeSurname);
        }
    }
}
