using CodeChallenge.Application.Commands.Permission;
using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Handlers.Permission;
using CodeChallenge.Application.Interfaces.Services;
using CodeChallenge.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace CodeChallenge.UnitTest
{
    public class RequestPermissionTest
    {
        private readonly Mock<IPermissionService> _permissionService = ServiceMock.GetPermissionService();

        [Fact]
        public void RequestPermission_returns_new_id()
        {
            var handler = new RequestPermissionHandler(_permissionService.Object);

            var result = handler.Handle(new RequestPermissionCommand() { IdPermissionType = 1, EmployeeSurname = "Perez", EmployeeForename = "José" });

            result.Should().Be(4);
        }

        [Fact]
        public void RequestPermission_with_invalid_permissionType_throws_notFound()
        {
            var handler = new RequestPermissionHandler(_permissionService.Object);

            Action act = () => handler.Handle(new RequestPermissionCommand() { IdPermissionType = 4, EmployeeSurname = "Perez", EmployeeForename = "José" });
            
            act.Should().Throw<NotFoundException>();
        }

    }
}
