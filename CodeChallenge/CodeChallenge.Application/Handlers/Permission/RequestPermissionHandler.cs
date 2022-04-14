using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.Services;

namespace CodeChallenge.Application.Handlers.Permission
{
    public class RequestPermissionHandler : ICommandHandler<RequestPermissionCommand, int>
    {
        private readonly IPermissionService _permissionService;

        public RequestPermissionHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public int Handle(RequestPermissionCommand command)
        {
            return _permissionService.Create(command.IdPermissionType.Value, command.EmployeeForename, command.EmployeeSurname);
        }
    }
}
