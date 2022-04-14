using CodeChallenge.Application.Handlers.Permission;
using CodeChallenge.Application.Interfaces.Services;
using CodeChallenge.Application.Queries.Permission;
using CodeChallenge.Domain.DTO.Permission;
using CodeChallenge.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CodeChallenge.UnitTest
{
    public class GetAllPermissionTest
    {
        private readonly Mock<IPermissionService> _permissionService = ServiceMock.GetPermissionService();

        [Fact]
        public void GetAllPermissionHandlerTest()
        {
            var handler = new GetAllPermissionHandler(_permissionService.Object);

            var result = handler.Handle(new GetPermissionQuery());

            result.Should().BeOfType<List<PermissionDto>>().And.HaveCount(3);
        }
    }
}
