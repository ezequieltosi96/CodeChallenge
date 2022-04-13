using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.Mediator.Query;
using CodeChallenge.Application.Queries.Permission;
using CodeChallenge.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.WebApi.Controllers
{
    [Route("api/permission")]
    [ApiController]
    public class PermissionController : ApiControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandProcessor _commandProcessor;

        public PermissionController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        [HttpGet("all")]
        public IActionResult GetPermissions([FromQuery] GetPermissionQuery query)
        {
            var result = _queryProcessor.Process(query);

            return OkIfNotNullNotFoundOtherwise(result);
        }

        [HttpPut("modify")]
        public IActionResult ModifyPermission(ModifyPermissionCommand command)
        {
            var result = _commandProcessor.Process(command);

            return Ok(result);
        }

        [HttpPost("request")]
        public IActionResult RequestPermission(RequestPermissionCommand command)
        {
            var result = _commandProcessor.Process(command);

            return Ok(result);
        }
    }
}
